
var phoebe = function() {
	
	var handleLeftNavActive = function($dom) {
		$('ul#left-nav').children().removeClass('active open');	
		
		var parent = $dom.parent();
		parent.addClass('active');		
		
		var li = $dom.closest('li.left-nav-first');
		li.addClass('active open');
		li.find('a').append('<span class="selected"></span>');
		li.find('.arrow').addClass('open');
	}
	
	var handleTostarMessage = function(message) {
		
		toastr.options = {
			"closeButton": true,			
			"progressBar": true,
			"positionClass": "toast-top-center",
			"onclick": null,
			"showDuration": "300",
			"hideDuration": "1000",
			"timeOut": "5000",
			"extendedTimeOut": "1000",
			"showEasing": "swing",
			"hideEasing": "linear",
			"showMethod": "fadeIn",
			"hideMethod": "fadeOut"
		};
		toastr['info'](message);
	}
	
	/* init datatable with filter */
	var handleInitDatatable = function($dom) {
		var oTable = $dom.DataTable({
			"order": [],

			"lengthMenu": [
				[5, 10, 20, -1],
				[5, 10, 20, "All"] // change per page values here
			],
			// set the initial value
			"pageLength": 10,

			"pagingType": "bootstrap_full_number",

			"language": {
					"lengthMenu": "  _MENU_ 记录",
					"sLengthMenu": "每页 _MENU_ 条记录",
					"sInfo": "显示 _START_ 至 _END_ 共有 _TOTAL_ 条记录",
					"sInfoEmpty": "记录为空",
					"sInfoFiltered": " - 从 _MAX_ 条记录中",
					"sZeroRecords": "结果为空",
					"sSearch": "搜索:",
					"paginate": {
						"previous":"Prev",
						"next": "Next",
						"last": "Last",
						"first": "First"
					}
				},

			"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r><'table-scrollable't><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12' p>>", // horizobtal scrollable datatable
			
			initComplete: function () {
				var api = this.api();
	 
				api.columns().indexes().flatten().each( function ( i ) {
					var column = api.column( i );
					if ($(column.footer()).attr('data-filter') == 'true') {
					
						var select = $('<select class="form-control"><option value=""></option></select>')
							.appendTo( $(column.footer()).empty() )
							.on( 'change', function () {
								var val = $.fn.dataTable.util.escapeRegex(
									$(this).val()
								);
		 
								column
									.search( val ? '^'+val+'$' : '', true, false )
									.draw();
							});
	 
						column.data().unique().sort().each( function ( d, j ) {
							var re = /<[^>]+>/;
							if (re.test(d)) {
								select.append('<option value="' + $(d).html() + '">' + $(d).html() + '</option>')
							} else {
								select.append('<option value="' + d + '">' + d + '</option>')
							}
						});
					}
				} );
			}
		});
		
		return oTable;
	}
	
	var handleInitDatePicker = function($dom, today) {
		if (today == true) {
			$dom.datepicker({
				format: "yyyy-mm-dd",
				weekStart: 7,
				language: "zh-CN",
				autoclose: true,
				todayHighlight: true
			});
		} else {
			$dom.datepicker({
                format: "yyyy-mm-dd",
                weekStart: 7,
                language: "zh-CN",
                autoclose: true
            });
		}
	}
	
	var handleInitSelect2 = function($dom) {
		$dom.select2({
            placeholder: "请选择",
            allowClear: true
        });
	}
	
	function handlePrint(obj) {
		//打开一个新窗口newWindow
		var newWindow = window.open("打印窗口", "_blank");
		//要打印的div的内容
		var docStr = obj.innerHTML;
		//打印内容写入newWindow文档
		newWindow.document.write(docStr);
		//关闭文档
		newWindow.document.close();
		//调用打印机
		//newWindow.print();
		//关闭newWindow页面
		//newWindow.close();
	}
	
	return {
		
		leftNavActive: function($dom) {
			handleLeftNavActive($dom);
		},
		
		showMessage: function(message) {
			handleTostarMessage(message);
		},
		
		initDatatable: function($dom) {
			return handleInitDatatable($dom);
		},
		
		initDatePicker: function($dom, today) {
			handleInitDatePicker($dom, today);
		},
		
		initSelect2: function($dom) {
			handleInitSelect2($dom);
		},
		
		initPrint: function($dom) {
			handlePrint($dom);
		},
		
		showLoading: function() {
			$('div#ajax-load').show();
		},
		
		hideLoading: function() {
			$('div#ajax-load').hide();
		}
	}
}();