
$.get("/ClosedBusiness", function (data) {
    
    function ClosedBusinessListModel()
    {
        var self = this;
        self.Data = ko.mapping.fromJS(data);
        self.InvokeTag = function (place) {            
            $.get("/ClosedBusiness?tag="+place, function (data) {                
                ko.mapping.fromJS(data, self.Data);
            });
        };
        self.SearchBox = ko.observable('');
        self.InvokeSearch = function () {
            $.get("/ClosedBusiness?search=" + self.SearchBox(), function (data) {
                ko.mapping.fromJS(data, self.Data);
            });
        };
    }   
    ko.applyBindings(new ClosedBusinessListModel);
});
