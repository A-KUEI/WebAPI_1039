angular.module('todoApp', [])

var app = angular.module('todoApp', []);


app.run(function ($rootScope, $templateCache) {
    $rootScope.$on('$viewContentLoaded', function () {
        $templateCache.removeAll();
    });
});

app.controller('FetchController', ['$scope','$location', '$http', '$templateCache',
  function($scope,$location, $http, $templateCache) {
      $scope.method = 'GET';
      $scope.url = 'api/Preaudit/?Pno=88001333';

      $scope.pno = "";
      $scope.searchText = "";
      $scope.Message = "";
   

      $scope.hospitals = [{
          id: 1,
          name: '台北',
      }, {
          id: 2,
          name: '淡水',
      }, {
          id: 3,
          name: '台東',
      }, {
          id: 4,
          name: '新竹',
      }

      ];

      $scope.myhospital = $scope.hospitals[0];


      $scope.$location = $location;
      //$scope.ur = $scope.$location.url('http://localhost:64146/index.html?pno=88001555,hospital=1');
      var myUrl;
      myUrl = $scope.$location.absUrl();

      $scope.ur = $scope.$location.url(myUrl);
      $scope.loc1 = $scope.$location.search().pno;
      if ($location.url().indexOf('pno') > -1) {
          //$scope.pno = $location.url().split('=')[1];

          $scope.pno = $location.search().pno;
          $scope.hospital= $location.search().hospital;
          $scope.myHospital = $scope.hospitals[$location.search().hospital-1];
          
          $scope.url = 'api/Preaudit/?Pno=' + $scope.pno + '&hospital=' + $scope.myHospital.id;
          $scope.Message = '查詢中，請稍候！';



          $http({
              method: $scope.method,
              url: $scope.url,
              cache: $templateCache

          }).then(function successCallback(response) {
              // this callback will be called asynchronously
              // when the response is available

              $scope.status = response.status;
              $scope.data = response.data;
            

              if ($scope.data.length == 0) {
                  $scope.Message = '查無資料！';

              }
              else {
                  if ($scope.data == undefined) {
                      $scope.Message = '查詢中，請稍候！';
                  }
                  else {

                      $scope.Message = '完成查詢！';
                  }
              };



          }, function errorCallback(response) {
              // called asynchronously if an error occurs
              // or server returns response with an error status.

              $scope.data = response.data || 'Request failed';
              $scope.status = response.status;
              $scope.Message = '完成查詢發生錯誤！';
          });


       
      };
     
      //if ($location.search().pno.indexOf('?') > 0) {
      //            //query parameter existing 
      //            $scope.pno = $location.search().pno;
      //        };
      $scope.fetch = function () {
          $scope.code = null;
          $scope.response = null;

          //if ($scope.typeD==true and $scope.typeN==true and $scope.typeM==true)
          //{
          //    $scope.url=$scope.url + "&&Mode=ALL"
          //};


        

          $scope.url = 'api/Preaudit/?Pno=' + $scope.pno + '&hospital=' + $scope.myHospital.id;
          $scope.Message = '查詢中，請稍候！';
        
          

          $http({
              method: $scope.method,
              url: $scope.url,
              cache: $templateCache

          }).then(function successCallback(response) {
              // this callback will be called asynchronously
              // when the response is available

              $scope.status = response.status;
              $scope.data = response.data;

              if ($scope.data.length == 0) {
                  $scope.Message = '查無資料！';

              }
              else {
                  if ($scope.data == undefined) {
                      $scope.Message = '查詢中，請稍候！';
                  }
                  else {

                      $scope.Message = '完成查詢！';
                  }
              };



          }, function errorCallback(response) {
              // called asynchronously if an error occurs
              // or server returns response with an error status.

              $scope.data = response.data || 'Request failed';
              $scope.status = response.status;
              $scope.Message = '完成查詢發生錯誤！';
          });

      };

    

      $scope.updateModel = function(method, url) {
          $scope.method = method;
          $scope.url = url;
      };


      $scope.getCurtabtext = function (mysearch) {
          $scope.searchText=mysearch
      };


    
     

      
  }]);

//app.controller('TabController', function ($scope) {
//    this.tab = 1;
//    this.filter = "";
//    $scope.searchText = "";

//    $scope.getCurtext = function (url) {

//        $scope.searchText = url;

//    };

//    this.setTab = function (selectTab) {
//        this.tab = selectTab;
//        if (selectTab == 1) {
//            $scope.searchText = "健保署";
//        };
//        if (selectTab == 2) {
//            $scope.searchText = "藥委會";
//        };
//        if (selectTab == 3) {
//            $scope.searchText = "院內自審";
//        };
//    };
//    this.isSet = function (givenTab) {
//        return this.tab === givenTab;
//    };

//    this.setFilter = function (givenFilter) {
//        this.filter = givenFilter;
//    };
//});



//-----------------------------------------

  //.controller('TodoListController', function () {
  //    var todoList = this;
  //    todoList.todos = [
  //      { text: 'learn angular', done: true },
  //      { text: 'build an angular app', done: false }];

  //    todoList.addTodo = function () {
  //        todoList.todos.push({ text: todoList.todoText, done: false });
  //        todoList.todoText = '';
  //    };




  //    todoList.remaining = function () {
  //        var count = 0;
  //        angular.forEach(todoList.todos, function (todo) {
  //            count += todo.done ? 0 : 1;
  //        });
  //        return count;
  //    };

  //    todoList.archive = function () {
  //        var oldTodos = todoList.todos;
  //        todoList.todos = [];
  //        angular.forEach(oldTodos, function (todo) {
  //            if (!todo.done) todoList.todos.push(todo);
  //        });
  //    };







 