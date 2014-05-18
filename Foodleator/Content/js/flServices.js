/**
 * flServices Module
 *
 * Description
 */
angular.module('flServices', []).service('Foodleator', function($q, $timeout) {
	function Request(method, url) {
		var deferred = $q.defer();

		if (method == 'get' && url == '/meals') {
			$timeout(function() {
				deferred.resolve([{
					date: +new Date,
					name: "Pork Thing " + Math.random()
				}, {
					date: 1399602000000,
					name: "Chicken Thing"
				}, {
					date: 1399002000000,
					name: "Beef Thing"
				}, {
					date: 1399302000000,
					name: "Mac Thing"
				}]);
			}, 1000);
		}

		if (method == 'post' && url == '/meals') {
			$timeout(function() {
				deferred.resolve('200 OK');
			}, 1000);
		}

		return deferred.promise;
	}

	function query() {
		return Request('get', '/meals');
	};

	function submit() {
		return Request('post', '/meals');
	}

	return {
		query: query,
		submit: submit,
	};
});