function TaskViewModel($scope, $http) {

    $scope.Task = {
        "TaskCode": "",
        "TaskName": "",
        "TaskDescription": "",
        "IsComplete": "",
        "EnteredDate": "",
        "AssignedTo": "",
        "AssignedBy": ""
    };

    $scope.Tasks = {};

    $scope.$watch("Tasks", function () {
        for (var x = 0; x < $scope.Tasks.length; x++) {
            var Tsk = $scope.Tasks[x];
        }
    });


    $scope.Add = function () {
        $http({ method: "POST", data: $scope.Task, url: "/Api/ToDo" }).
            success(function (data, status, headers, config) {

                $scope.Tasks = data;

                $scope.Task = {
                    "TaskCode": "",
                    "TaskName": "",
                    "TaskDescription": "",
                    "IsComplete": "",
                    "EnteredDate": "",
                    "AssignedTo": "",
                    "AssignedBy": ""
                };
            });
    }


    $scope.Update = function () {
        $http({ method: "PUT", data: $scope.Task, url: "/Api/ToDo" }).
            success(function (data, status, headers, config) {

                $scope.Tasks = data;

                $scope.Task = {
                    "TaskCode": "",
                    "TaskName": "",
                    "TaskDescription": "",
                    "IsComplete": "",
                    "EnteredDate": "",
                    "AssignedTo": "",
                    "AssignedBy": ""
                };
            });
    }


    $scope.Delete = function () {

        $http.defaults.headers["delete"] = {
            'Content-Type': 'application/json;charset=utf-8'
        };//Prnv: Was put to address an issue in Angular 1.x versions
        //TODO: recheck whether this line is really required
        
        $http({ method: "DELETE", data: $scope.Task, url: "/Api/ToDo" }).
            success(function (data, status, headers, config) {

                $scope.Tasks = data;

                $scope.Task = {
                    "TaskCode": "",
                    "TaskName": "",
                    "TaskDescription": "",
                    "IsComplete": "",
                    "EnteredDate": "",
                    "AssignedTo": "",
                    "AssignedBy": ""
                };
            });
    }



    $scope.LoadByTaskCode = function (TaskCode) {
        $http({
            method: "GET",
            url: "/Api/Task?TaskCode=" + TaskCode
        }).
        success(function (data, status, headers, config) {
            $scope.Tasks = data;
        });
    }


    $scope.Load = function () {
        $http({ method: "GET", url: "/Api/ToDo" }).
    success(function (data, status, headers, config) {
        $scope.Tasks = data;

    });
    }

    $scope.Load();

}