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
			templateUrl: 'part/calendar.html',
			controller: 'CalendarController'
		}).
		when('/about', {
			templateUrl: 'part/about.html',
			controller: 'AboutController'
		}).
		otherwise({
			redirectTo: '/calendar'
		});
	}
);