var app = angular.module('app', ['ngResource']);

app.value('toastr', toastr);

app.factory('notifier', function (toastr) {
	return {
		notify: function (msg) {
			toastr.success(msg);
			console.log(msg);
		}
	}
});