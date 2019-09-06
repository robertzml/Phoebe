using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 自动编号记录业务类
    /// </summary>
    public class SequenceRecordBusiness : AbstractBusiness<SequenceRecord, string>, IBaseBL<SequenceRecord, string>
    {
        #region Function
        #endregion //Function

        #region Method
        /// <summary>
        /// 格式化编号
        /// </summary>
        /// <param name="format"></param>
        /// <param name="seq"></param>
        /// <param name="dt"></param>
        /// <param name="extParams"></param>
        /// <returns></returns>
        public string FormatSequence(string format, int seq, DateTime? dt, params string[] extParams)
        {
            string str = "";
            List<object> parameters = new List<object>();
            parameters.Add(seq);

            if (dt.HasValue)
                parameters.Add(dt.Value);

            if (extParams != null)
            {
                for (int i = 0; i < extParams.Length; i++)
                {
                    parameters.Add(extParams[i]);
                }
            }

            str = string.Format(format, parameters.ToArray());

            return str;
        }

        /// <summary>
        /// 生成下一个序列号
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">日期</param>
        /// <param name="extParams">额外参数</param>
        /// <returns></returns>
        public (string number, bool strict)GetNextSequence(string tableName, DateTime? dt, params string[] extParams)
        {
            var db = GetInstance();
            var result = db.Ado.UseTran<(string, bool)>(() =>
            {
                // find template
                var template = db.Queryable<SequenceTemplate>().Single(r => r.TableName == tableName);

                // find exist record
                SequenceRecord item;
                string currentDate = "";
                if (template.IncludeDate)
                {
                    string pattern = @"\{1:.+?\}";
                    var match = Regex.Match(template.Format, pattern);
                    if (match.Success)
                    {
                        string dtFormat = Regex.Replace(match.Value, "1", "0");
                        currentDate = string.Format(dtFormat, dt.Value);

                        item = db.Queryable<SequenceRecord>().First(r => r.TemplateId == template.Id && r.CurrentDate == currentDate);
                    }
                    else
                    {
                        throw new Exception("格式错误");
                    }
                }
                else
                {
                    item = db.Queryable<SequenceRecord>().First(r => r.TemplateId == template.Id);
                }

                // generate new record or update exist
                int seq = 0;
                if (item == null)
                {
                    seq = template.Initial;

                    SequenceRecord record = new SequenceRecord
                    {
                        Id = Guid.NewGuid().ToString(),
                        TemplateId = template.Id,
                        TableName = tableName,
                        CurrentDate = currentDate,
                        CurrentSequence = seq
                    };

                    if (!template.Strict)
                        db.Insertable(record).ExecuteCommand();
                }
                else
                {
                    seq = item.CurrentSequence + template.Step;
                    item.CurrentSequence = seq;

                    if (!template.Strict)
                        db.Updateable(item).ExecuteCommand();
                }

                // format sequence
                var str = FormatSequence(template.Format, seq, dt, extParams);
                return (str, template.Strict);
            });

            if (result.IsSuccess)
            {
                return result.Data;
            }
            else
            {
                return ("", false);
            }
        }
        #endregion //Method
    }
}
