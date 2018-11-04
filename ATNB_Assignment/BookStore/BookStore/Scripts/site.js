(function (global) {
    "use strict;"

    $(document).ready(function () {
        let
            $crudBookForm = $("#crud-book-form")
        ;

        $crudBookForm.validate({
            messages: {
                title: "Please enter the title",
                sumary: "Please enter the sumary",
                price: "Please enter the price",
                Quantity: "Please enter the quantity",
            },
            errorElement: "div",
            errorPlacement: function (error, element) {
                error.addClass("invalid-feedback");

                error.insertAfter(element);
            },
            highlight: function (element, errorClass, validClass) {
                $(element).parents("form").addClass("was-validated");
            },
            unhighlight: function (element, errorClass, validClass) {
            }
        });

        $('#categories-table').DataTable({
            ajax: location.origin + "/admin/Category/GetCategories",
            "columnDefs": [{
                targets: 3,
                data: "CateID",
                "render": function (data, type, full, meta) {

                    let url = '/Admin/Category';

                    let result = '<a href="#">Edit</a> | ' +
                        '<a href=' + url + '/DetailCategory/' + data + '>Details</a> | ' +
                        '<a href="#">Delete</a>';

                    return result;
                }
            }],
            "columns": [
                { "data": "CateID" },
                { "data": "CateName" },
                { "data": "Description" },
            ]
        });


        $('#publishers-table').DataTable({
            ajax: location.origin + "/admin/Publisher/GetAllPublishers",
            "columnDefs": [{
                targets: 3,
                data: "PublisherID",
                "render": function (data, type, full, meta) {

                    let url = '/Admin/Publisher';

                    let result = '<a href="#">Edit</a> | ' +
                        '<a href=' + url + '/DetailPublisher/' + data + '>Details</a> | ' +
                        '<a href="#">Delete</a>';

                    return result;
                }
            }],
            "columns": [
                { "data": "PublisherID" },
                { "data": "PublisherName" },
                { "data": "Description" },
            ]
        });

        $('#authors-table').DataTable({
            ajax: location.origin + "/admin/Author/GetAuthors",
            "columnDefs": [{
                targets: 3,
                data: "AuthorID",
                "render": function (data, type, full, meta) {

                    let url = '/Admin/Author';

                    let result = '<a href="#">Edit</a> | ' +
                        '<a href=' + url + '/DetailAuthor/' + data + '>Details</a> | ' +
                        '<a href="#">Delete</a>';

                    return result;
                }
            }],
            "columns": [
                { "data": "AuthorID" },
                { "data": "AuthorName" },
                { "data": "History" },
            ]
        });
    
        $('#books-table').DataTable({
            ajax: location.origin + "/admin/Book/GetBooks",
            "columnDefs": [{
                "targets": 6,
                "data": "BookID",
                "render": function (data, type, full, meta) {

                    let url = '/Admin/Book';

                    let result = '<a href="#">Edit</a> | ' +
                        '<a href=' + url + '/DetailBook/' + data + '>Details</a> | ' +
                        '<a href="#">Delete</a>';

                    return result;
                }
            }],
            "columns": [
                { "data": "BookID" },
                { "data": "Title" },
                {
                    "data": "Price",
                    "render": function (data, type, full, meta) {
                        return data.toLocaleString();
                    }
                },
                {
                    "data": "Quantity",
                    "render": function (data, type, full, meta) {
                        return data.toLocaleString();
                    }
                },
                {
                    "data": "ImgUrl",
                    "render": function (data, type, full, meta) {
                        return '<img src="~/Assets/'+data+'" alt="No image"/>'
                    }
                },
                {
                    "data": "IsActive",
                    "render": function (data, type, full, meta) {
                        return '<input type="checkbox" checked="IsActive" disabled/>'
                    }
                }
            ]
        });
    });

})((this || 0).self || global);

