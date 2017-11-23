var app = angular.module('myApp', [])
app.controller("CustomerController", function ($scope, $http)
{
  

    $scope.NameControlImport = "Customer";

    $scope.Init = function () {
        $scope.showLoading = true;
        $http.get("/Admin/CustomerGroup/GetList").then(
            function (res) {
                var data = res.data;
                $scope.customerGroups = data;
            },
            function (resErr) {
            });
    };
    $scope.LoadDataSource = function ()
    {
        $scope.dataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: "/Admin/Customer/GetList",
                    dataType: "json"
                }
            },
            pageSize: 10,
            schema: {
                model: {
                    fields:
                    {
                        CustomerID: { type: "string" },
                        Name: { type: "string" },
                        //ShipName: { type: "string" },
                        CreateDate: { type: "date" },
                        //ShipCity: { type: "string" }
                    }
                }
            }
        });
        $scope.dataSource.group([{ field: "GroupName" }]);
    };


    $scope.clickRefreshGridKendo = function () 
    {
        $("#grid .k-pager-refresh").trigger('click');
    };

    $scope.ReLoad = function ()
    {

        $scope.showListErrorFileImport = false;
        $scope.LoadDataSource();
        $scope.clickRefreshGridKendo();
        $scope.Init();
        $scope.disableReset = false;
        $scope.disableEdit = false;
        $scope.disableDelete = false;
        $scope.disableSave = true;
        $scope.customerID = "";

        $scope.txtCustomerGroup = "VN";
        //$scope.customerID = "";
        $scope.customerName = "";
        $scope.customerAddress = "";
        $scope.customerTel = "";
        $scope.customerEmail = "";
        $scope.customerBirthday = "";
        $scope.customerCreateDate = "";
        $scope.customerDescription = "";
    }


    $scope.load = function () 
    {
        $("#grid").kendoGrid({
            dataSource: {
           
                transport: {
                    read: {
                        url: "/Admin/Customer/GetList",
                        dataType: "json"
                    }
                },
                pageSize:10
            },
            height: 550,
            resizable: true,
            groupable: true,
            sortable: true,
            pageable: {
                refresh: true,
                pageSizes: true,
                buttonCount: 5
            },
            columns: [
                {
                    field: "CustomerID",
                    title: "Mã khách hàng", width: 120
                },
                {
                    field: "GroupName",
                    title: "Khu vực",width:140
                },
                {
                    field: "Name",
                    title: "Tên khách hàng", width: 150
                },
                {
                    field: "Address",
                    title: "Địa chỉ", width: 240
                },
                {
                    field: "Birthday",
                    title: "Ngày sinh", width: 120
                     , template: "#= kendo.toString(kendo.parseDate(Birthday, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                    //, hidden: true,//vi export excel no ra /Date(1444289073317)/
                    filterable: {
                        ui: function (element) {
                            element.kendoDatePicker(); // initialize a Kendo UI DatePicker
                        },
                        cell: {
                            operator: "gte"//chon truoc greatethanorequal
                        }
                    }
                },
                {
                    field: "Tel",
                    title: "Điện thoại", width: 130
                },
                {
                    field: "Email",
                    title: "Email", width: 195
                },
                {
                    field: "CreateDate",
                    title: "Ngày tạo", width: 120
                    //,format: "{0:dd/MM/yyyy}"
                    , template: "#= kendo.toString(kendo.parseDate(CreateDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                    //, hidden: true,//vi export excel no ra /Date(1444289073317)/
                    filterable: {
                        ui: function (element) {
                            element.kendoDatePicker(); // initialize a Kendo UI DatePicker
                        },
                        cell: {
                            operator: "gte"//chon truoc greatethanorequal
                        }
                    }
                },
                {
                    field: "Description",
                    title: "Ghi chú", width: 180
                }
            ],
            autoBind: true,
            groupable: false,
            editable: false,
            selectable: 'row',
            change: function ()
            {
                var selectedRows = this.select();
                var rowData = this.dataItem(selectedRows[0]);
                $scope.disableReset=true;
                $scope.disableID = true;
                $scope.customerID = rowData.CustomerID;
                $scope.txtCustomerGroup = rowData.GroupID;
                $scope.customerName = rowData.Name;
                $scope.customerAddress = rowData.Address;
                $("#txtBirthday").kendoDatePicker({
                    value: rowData.Birthday,
                    format: "dd/MM/yyyy"
                });
               
                $scope.customerTel = rowData.Tel;
                $scope.customerEmail = rowData.Email;
                $("#txtCreateDate").kendoDatePicker({
                    value: rowData.CreateDate,
                    format: "dd/MM/yyyy"
                });
               
                $scope.customerDescription = rowData.Description;
                console.log($scope.txtCustomerGroup);
                $scope.$apply();

            }
        
        });
        $scope.Init();
        $scope.disableSave = true;
        
    }

    $scope.edit = function () {
       

        var dataJson = { // 
            Customer_ID: $scope.customerID,
            OrderID: 0,
            CustomerName: $scope.customerName,
            Customer_Type_ID: "1",
            Customer_Group_ID: $scope.txtCustomerGroup,
            CustomerAddress: $scope.customerAddress,
            Barcode: $scope.customerID,
            Tel: $scope.customerTel,
            Email: $scope.customerEmail,
            Birthday: $scope.customerBirthday,
            Description: $scope.customerDescription
        };
        $scope.showLoading = true;
        $scope.disableSave = true;
        $http.post("/Admin/Customer/Update", dataJson).then(
            function (response) { // success 
                //$("#btnSave").button('reset');
               // $scope.showLoading = false;
                var data = response.data;
                if (data.status) {
                   // $scope.reset();
                    $scope.LoadDataSource();
                    $scope.clickRefreshGridKendo();
                    //$('#myModal').modal('hide');
                    alert("Sửa thành công!");
                    $scope.customerID = "";

                    $scope.txtCustomerGroup = "VN";
                    //$scope.customerID = "";
                    $scope.customerName = "";
                    $scope.customerAddress = "";
                    $scope.customerTel = "";
                    $scope.customerEmail = "";
                    $scope.customerBirthday = "";
                    $scope.customerCreateDate = "";
                    $scope.customerDescription = "";
                    $scope.disableReset = false;
                    $scope.disableEdit = false;
                    $scope.disableDelete = false;
                    $scope.disableSave = true;
                }
                else 
                {
                    alert(data.message);
                }
            },
            function (response) { // error
            
            });
    };

    $scope.reset = function () {
      
        $scope.showLoading = true;
        $scope.disableEdit = true;
        $scope.disableDelete = true;
        $scope.disableSave = false;
        $http.get("/Admin/" + $scope.NameControlImport + "/NewID").then(
            function (res) {
                var data = res.data;
                $scope.customerID = data.message;
                
                $scope.txtCustomerGroup="VN";
             
                $scope.customerName = "";
                $scope.customerAddress = "";
                $scope.customerTel = "";
                $scope.customerEmail = "";
                $scope.customerBirthday = "";
                $scope.customerCreateDate = kendo.toString(kendo.parseDate(new Date(), 'yyyy-MM-dd'), "dd/MM/yyyy");
                $scope.customerDescription = "";
           
            },
            function (resErr) {
            });
     
        $scope.disableID = false;
    };


    $scope.save = function () 
    {
        var dataJson =
        { // 
            Customer_ID: $scope.customerID,
            OrderID: 0,
            CustomerName: $scope.customerName,
            Customer_Type_ID: "1",
            Customer_Group_ID: $scope.txtCustomerGroup,
            CustomerAddress: $scope.customerAddress,
            Barcode: $scope.customerID,
            Tel: $scope.customerTel,
            Email: $scope.customerEmail,
            Birthday: $scope.customerBirthday,
            Description: $scope.customerDescription
        }
        $scope.showLoading = true;
        $http.post("/Admin/Customer/Insert", dataJson).then(
        function (response)
        { // success 
            var data = response.data;
            if (data.status)
            {
                $scope.reset();
                $scope.LoadDataSource();
                $scope.clickRefreshGridKendo();
                alert("Thêm thành công!");
               
          
            }
            else
            {
                alert(data.message);
            }
        },
            function (response) { // error
                      
            });
    }

    $scope.delete = function () {
        $scope.showListErrorFileImport = false;
        var grid = $("#grid").data("kendoGrid");
        var row = grid.select();
        var dataRow = grid.dataItem(row);
        if (dataRow == null) {
            alert("Chọn dòng để xóa");
        }
        else {
            var dataJson = { CustomerID: dataRow.CustomerID };
            var url = "/Admin/Customer/Delete";
            if (confirm("Bạn muốn xóa dòng đang chọn?")) {
                $scope.showLoading = true;
                $http.post(url, dataJson).then(
                function (response) {
                    $scope.showLoading = false;
                    var data = response.data;
                    if (data.status) {
                        //$scope.load();
                        $scope.LoadDataSource();
                        $scope.clickRefreshGridKendo();
                        $scope.disableReset=false;
                    }
                    else {
                        alert(data.message);
                    }
                },
                function (response) {
                    $scope.showLoading = false;
                });
            }
        }
    };

});


