
$.get("/ClosedBusiness", function (data) {
    
    function ClosedBusinessListModel()
    {
        var self = this;
        self.Data = ko.mapping.fromJS(data);
        self.InvokeTag = function (place) {
            alert(place);
            $.get("/ClosedBusiness?tag="+place, function (data) {
                alert("Check");
                ko.mapping.fromJS(data, self.Data);
            });
            };
    }   
    ko.applyBindings(new ClosedBusinessListModel);
});
