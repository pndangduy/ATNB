[‎11 /‎6 /‎2018 1: 12 PM] Nguyen Tan Vang(FA.G0):
function deleteBook(bookid) {
	if (bookid == 0) {
		window.alert("Book is not exist!");
	}
	else {
		var xhttp = new XMLHttpRequest();
		xhttp.onreadystatechange = function () {
			if (this.readyState == 4 && this.status == 200 && this.responseText == "True") {
				var tr = "#tr" + bookid;
				$(tr).css("display", "none");
				window.alert("Delete book success!");
			}
		};
		xhttp.open("DELETE", "Delete?Id=" + bookid, true);
		xhttp.send();
	}
} 
