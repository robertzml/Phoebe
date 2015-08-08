
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
	
	return {
		
		leftNavActive: function($dom) {
			handleLeftNavActive($dom);
		},
		
		showMessage: function(message) {
			handleTostarMessage(message);
		}
	}
}();