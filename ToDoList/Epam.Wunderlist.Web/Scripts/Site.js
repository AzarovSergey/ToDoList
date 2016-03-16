function DragItemStart(event) {
    draggedItem = event.toElement;
    // console.log(event);
    console.log(draggedItem);
}

function DragItemFinish(event) {
    var todolist = event.toElement;
    var itemId = $(draggedItem).attr('data-db-id');
    var todolistId = $(todolist).attr('data-db-id');
    var url = '/item/drag?itemId=' + itemId + "&todolistId=" + todolistId;
    console.log(url);
    http.post(url).then(function () {
        scope.RefreshToDoList();
    });
}
//event.stopPropagation();
var SelectedToDoListId = undefined;
var http;
var scope;
var creatingFolderId;
var targetInstanceId;
var draggedItem;

$('#user-info').hide();
$('#user-info-button').click(function () {
    $('#user-info').toggle();
});
RightVisibility(false);

function RightVisibility(isVisible) {
    // $('#right').toggle(isVisible);
    var opacity = isVisible + 0;
    //$('#right').css('opacity', opacity);

    var right = $('#right');
    right.css('display', 'block');
    right.animate({ 'opacity': opacity }, 1000);
    if (!isVisible)
        right.css('display', 'none');

}

var isLeftHide = false;
$('#menu-toggle-button').click(function () {
    if (isLeftHide) {
        $('#left-container').css('width', '300px');
        $('#center').css('left', '300px');
        $('#create-folder').show();
    } else {
        $('#left-container').css('width', '50px');
        $('#center').css('left', '50px');
        $('#create-folder').hide();
    }
    isLeftHide ^= true;
});


var app = angular.module('app', []);
app.controller('main', function ($scope, $http) {
    http = $http;
    scope = $scope;
    $scope.activeItems = [];
    $scope.disabledItems = [];
    $scope.itemEditor = { id: 0, name: '', note: '' };


    $scope.RefreshFolders = function () {
        $http.get('/folder/GetFolders/').then(function (responce) {
            $scope.folders = responce.data;
        });
    }


    $scope.ToggleFolder = function (event) {
        $(event.currentTarget).siblings('.to-do-list-container').toggle(500);
    };


    $scope.SetSelectedToDoList = function (Id) {
        if (Id === undefined)
            return;
        $http.get('/item/GetItems?toDoListId=' + Id).then(function (responce) {
            var allItems = responce.data;
            $scope.activeItems = [];
            $scope.disabledItems = [];
            for (var itemIndex in allItems) {
                var item = allItems[itemIndex];
                var dueDateTimeMilliseconds = +item.DueDateTime.replace(/\/Date\((-?\d+)\)\//, '$1');;
                var date = new Date(dueDateTimeMilliseconds);
                if (+date.getFullYear() != 9999)
                    item.dueDate = date.getDate() + '.' + (date.getMonth() + 1) + '.' + date.getFullYear();
                else
                    item.dueDate = '';
                if (item.IsCompleted) {
                    $scope.disabledItems.push(item);
                } else {
                    $scope.activeItems.push(item);
                }
            }
            SelectedToDoListId = Id;
        });
    }


    $scope.RefreshToDoList = function () {
        $scope.SetSelectedToDoList(SelectedToDoListId);
    }

    $scope.SetDueDate = function (event) {
        var due = $('#due-date')[0].value;
        if (due == "")
            return;
        $http.post('/item/SetDueDate?itemId=' + $scope.itemEditor.id + "&dueDate=" + due).then(function () {
            $scope.RefreshToDoList();
        });
    }

    $scope.SetCompletion = function (event, isCompleted) {
        itemId = $(event.currentTarget).attr('data-db-id');
        $http.post('/item/SetCompletion?itemId=' + itemId + "&isCompleted=" + isCompleted).then(function () {
            $scope.RefreshToDoList();
        });
    }


    $scope.CahngeUserName = function (event) {
        var path = "/account/ChangeName?id=" + $scope.user.Id + "&name=" + $(event.target).siblings('input')[0].value;
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                $scope.RefreshUser();
            },
            error: function (responce) {
            }
        });
    };


    $scope.AddFolder = function (event) {
        var path = "/folder/create?name=" + $(event.target).siblings('input')[0].value + "&folderId=" + creatingFolderId;
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                $scope.RefreshFolders();
            },
            error: function (responce) {
            }
        });
    }


    $scope.DeleteFolder = function (folderId) {
        var path = '/folder/delete?folderId=' + folderId;
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                $scope.RefreshFolders();
            },
            error: function (responce) {
            }
        });
    }


    $scope.DeleteToDoList = function (todolistId) {
        var path = '/todolist/delete?id=' + todolistId;
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                $scope.RefreshFolders();
            },
            error: function (responce) {
            }
        });
    }


    $scope.AddToDoList = function (event) {
        var path = "/todoList/create?name=" + $(event.target).siblings('input')[0].value + "&folderId=" + creatingFolderId;
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                scope.SetSelectedToDoList(SelectedToDoListId);
                $scope.RefreshFolders();
            },
            error: function (responce) {
            }
        });
    }


    $scope.EditToDoList = function (event) {
        var path = "/todoList/Rename?name=" + $(event.target).siblings('input')[0].value + "&Id=" + targetInstanceId;
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                $scope.RefreshFolders();
            },
            error: function (responce) {
            }
        });
    }


    $scope.EditItem = function (event) {
        RightVisibility(false);
        var btn = $(event.target);
        var path = "/item/update?name=" + btn.siblings('[name=name]')[0].value + "&Id=" + btn.attr('data-db-id') + "&note=" + btn.siblings('[name=note]')[0].value;
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                $scope.RefreshToDoList();
            },
            error: function (responce) {
            }
        });
    }


    $scope.RemoveItem = function (event) {
        RightVisibility(false);
        var path = "/item/Delete?id=" + $(event.target).attr('data-db-id');
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                $scope.RefreshToDoList();
            },
            error: function (responce) {
            }
        });
    }


    $scope.EditFolder = function (event) {
        var path = "/folder/Rename?name=" + $(event.target).siblings('input')[0].value + "&Id=" + targetInstanceId;
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                $scope.RefreshFolders();
            },
            error: function (responce) {
            }
        });

    }



    $scope.PrepareToUpdateItem = function (event, item) {
        RightVisibility(true);
        var btn = $(event.target);
        $scope.itemEditor = {
            id: item.Id,
            name: item.Name,
            note: item.Note
        };
    }


    $scope.ChangePhoto = function (event) {
        var form = $('#user-image-form')[0];
        var data = new FormData(form);
        var path = "/account/ChangePhoto";
        var f = $('#input-photo')[0].files;
        jQuery.each(f, function (i, file) {
            data.append('file-' + i, file);
        });
        jQuery.ajax({
            url: path,
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
            success: function (data) {
                var photo = $('#photo');
                var src = photo.attr('src');
                photo.attr('src', src + '?randomString=' + new Date());
            },
            error: function (data) {
            }
        });
    }



    $scope.RefreshUser = function () {
        $http.get('/account/UserAccount').then(function (responce) {
            $scope.user = responce.data;
        });
    }

    $scope.RefreshUser();
    $scope.RefreshFolders();
});//main controller initialization

function ItemUrlSuffix(name, toDoListId, id, isStarred, orderIndex, note, isCompleted, dueDateTime) {
    id = id || 0;
    dueDateTime = dueDateTime || 0;
    isCompleted = isCompleted || false;
    note = note || "";
    orderIndex = orderIndex || 0;
    isStarred = isStarred || false;
    return "?Name=" + name + "&Id=" + id + "&ToDoListId=" + toDoListId + "&DueDateTime=" + dueDateTime + "&IsStarred=" + isStarred + "&OrderIndex=" + orderIndex + "&Note=" + note + "&IsComleted=" + isCompleted;
}

function AddItem(event) {
    if (event.keyCode === 13) {
        if (SelectedToDoListId === undefined)
            return;
        var path = "/item" + ItemUrlSuffix(event.target.value, SelectedToDoListId);
        $.ajax({
            method: 'POST',
            url: path,
            success: function (responce) {
                scope.SetSelectedToDoList(SelectedToDoListId);
            },
            error: function (responce) {
            }
        });
    }
}
