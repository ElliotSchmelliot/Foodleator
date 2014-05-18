/**
 * controllers, lol
 */

function CalendarController($scope, Foodleator) {
	$scope.query = function() {
		$scope.isLoadingData = true;
		Foodleator.query().then(function(data) {
			$scope.data = data;
			$scope.isLoadingData = false;
		}, function(error) {
			$scope.isLoadingData = false;
			alert('error!', error);
		});
	}

	$scope.submitMeal = function(meal) {
		$scope.isLoadingSubmit = true;
		Foodleator.submit(meal).then(function(data) {
			$scope.isLoadingSubmit = false;
			$scope.query();
			console.log(data);
		}, function(error) {
			$scope.isLoadingSubmit = false;
			alert('error!', error);
		});
	}

	$scope.query();

}

function AboutController($scope) {}