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

		// validation should not be in this function
		if (!meal || meal.name == "") {
			return;
		}
		if (!assertType(meal.date, Date)) {
			alert('Invalid date!');
			return;
		}
		if (!assertType(meal.name, String)) {
			alert('Invalid name!');
			return;
		}

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

function assertType(val, type) {
	if (type == String) {
		return typeof val === 'string';
	} else if (type == Number) {
		return typeof val === 'number';
	} else if (type == Boolean) {
		return typeof val === 'boolean';
	}
	return val instanceof type;
}