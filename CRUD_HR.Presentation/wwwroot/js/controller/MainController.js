const baseUrl = 'http://localhost:7022';

app.controller('MainController', ['$scope', '$http', function ($scope, $http) {

    //Category 

    $scope.Categories = [];

    let loadCats = () => {
        let url = baseUrl + '/api/v1/Get/Category';
        $http({
            method: 'GET',
            url: url,
        })
            .then(function (success) {
                $scope.Categories = [].concat(success.data);
                console.log(success)
            }, function (error) {
                console.error(error)
            });
    };

    $scope.registerCat = function () {
        if ($scope.inputCatName != null && $scope.inputCatName != "") {
            let url = baseUrl + '/api/v1/Add/Category';
            let data = { "name": $scope.inputCatName };
            $http({
                method: 'POST',
                url: url,
                data: JSON.stringify(data)
            })
                .then(function (success) {
                    $scope.Categories.push(success.data);
                    console.log(success)
                }, function (error) {
                    console.error(error)
                });
            $scope.inputCatName = '';
        }
    }

    $scope.deleteCategory = function (id) {
        let url = baseUrl + '/api/v1/Delete/Category/' + id;
        $http({
            method: 'DELETE',
            url: url,
        })
            .then(function (success) {
                loadCats();
                console.log(success)
            }, function (error) {
                console.error(error)
            });
        $scope.inputCatName = '';
    }

    let editCatId;
    $scope.editCategory = function (id,name) {
        editCatId = id;
        $scope.inputEditCatName = name;
    }

    $scope.regEditCategory = function () {
        let url = baseUrl + '/api/v1/Update/Category/' + editCatId;
        let data = { "name": $scope.inputEditCatName };
        $http({
            method: 'PUT',
            url: url,
            data: JSON.stringify(data)
        })
            .then(function (success) {
                loadCats();
                console.log(success)
            }, function (error) {
                console.error(error)
            });
        $scope.inputCatName = '';
    }

    // Feature
    $scope.Features = [];

    let loadFeatures = () => {
        let url = baseUrl + '/api/v1/Get/Feature';
        $http({
            method: 'GET',
            url: url,
        })
            .then(function (success) {
                $scope.Features = [].concat(success.data);
                console.log(success)
            }, function (error) {
                console.error(error)
            });
    };

    $scope.registerFeature = function () {
        if ($scope.inputFeatureName != null && $scope.inputFeatureName != "") {
            let url = baseUrl + '/api/v1/Add/Feature';
            let data = { "name": $scope.inputFeatureName };
            $http({
                method: 'POST',
                url: url,
                data: JSON.stringify(data)
            })
                .then(function (success) {
                    $scope.Features.push(success.data);
                    console.log(success)
                }, function (error) {
                    console.error(error)
                });
            $scope.inputFeatureName = '';
        }
    }

    $scope.deleteFeature = function (id) {
        let url = baseUrl + '/api/v1/Delete/Feature/' + id;
        $http({
            method: 'DELETE',
            url: url,
        })
            .then(function (success) {
                loadFeatures();
                console.log(success)
            }, function (error) {
                console.error(error)
            });
        $scope.inputFeatureName = '';
    }

    let editFeatureId;
    $scope.editFeature = function (id, name) {
        editFeatureId = id;
        $scope.inputEditFeatureName = name;
    }

    $scope.regEditFeature = function () {
        let url = baseUrl + '/api/v1/Update/Feature/' + editFeatureId;
        let data = { "name": $scope.inputEditFeatureName };
        $http({
            method: 'PUT',
            url: url,
            data: JSON.stringify(data)
        })
            .then(function (success) {
                loadFeatures();
                console.log(success)
            }, function (error) {
                console.error(error)
            });
        $scope.inputFeatureName = '';
    }

    loadCats();
    loadFeatures();
}]);
