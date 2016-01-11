
$.get("/ClosedBusiness", function (data) {
    
    function ClosedBusinessListModel()
    {
        var self = this;
        self.Data = ko.mapping.fromJS(data);
        self.InvokeTag = function (place) {
            $.get("/ClosedBusiness", function (data) {
        }
    }   
    ko.applyBindings(new ClosedBusinessListModel);
});
