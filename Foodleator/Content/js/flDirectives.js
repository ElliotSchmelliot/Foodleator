angular.module('flDirectives', []).
directive('loader',
	function($http, $animate) {
		return {
			restrict: 'E',
			replace: true,
			template: '<div class="loader"><img src="/Content/img/loader.gif"/>Loading...</div>',
			link: function(scope, element, attr) {
				scope.$watch(attr['when'], function(value) {
                    $animate[!value ? 'addClass' : 'removeClass'](element, 'loader-done');
				});
			}
		};

	}
);