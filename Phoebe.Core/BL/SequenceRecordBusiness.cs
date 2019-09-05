using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 自动编号记录业务类
    /// </summary>
    public class SequenceRecordBusiness : AbstractBusiness<SequenceRecord, string>, IBaseBL<SequenceRecord, string>
    {
        #region Function
        private string FormatSequence(string format, int seq, DateTime? currentDate, List<string> extParams)
        {
            string str = "";
            if (currentDate.HasValue)
            {
                str = string.Format(format, seq, currentDate, extParams.ToArray());
            }
            else
            {
                str = string.Format(format, seq, extParams.ToArray());
            }

            return str;
        }
        #endregion //Function

        #region Method
        public string GetNextSequence(string tableName, DateTime? currentDate, List<string> extParams)
        {
            var db = GetInstance();
            var result = db.Ado.UseTran<string>(() =>
            {
                // find template
                var template = db.Queryable<SequenceTemplate>().Single(r => r.TableName == tableName);

                SequenceRecord record = new SequenceRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    TemplateId = template.Id,
                    TableName = tableName,
                    CurrentDate = currentDate
                };

                // find record
                SequenceRecord item;
                if (template.IncludeDate)
                {
                    item = db.Queryable<SequenceRecord>().First(r => r.TemplateId == template.Id && r.CurrentDate == currentDate.Value);
                }
                else
                {
                    item = db.Queryable<SequenceRecord>().First(r => r.TemplateId == template.Id);
                }

                int seq = 0;
                if (item == null)
                {
                    seq = template.Initial;
                }
                else
                {
                    seq = item.CurrentSequence + template.Step;
                }

                record.CurrentSequence = seq;

                var str = FormatSequence(template.Format, seq, currentDate, extParams);
                return str;
            });

            if (result.IsSuccess)
            {              
                return result.Data;
            }
            else
            {
                return "";
            }
        }
        #endregion //Method
    }
}
