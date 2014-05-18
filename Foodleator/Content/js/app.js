/**
 * fl Module
 *
 * Description
 */
var fl = angular.module('fl', [
	'ngRoute',

	'flServices',
	'flDirectives',

	'mgcrea.ngStrap', // angularstrap
]);

fl.config(
	function($routeProvider) {
		$routeProvider.
		when('/calendar', {
			templateUrl: '/Content/part/calendar.html',
			controller: 'CalendarController'
		}).
		when('/about', {
			templateUrl: '/Content/part/about.html',
			controller: 'AboutController'
		}).
		otherwise({
			redirectTo: '/calendar'
		});
	}
);