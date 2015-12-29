
$.get("/ClosedBusiness", function (data) {
    
    function ClosedBusinessListModel()
    {
        var self = this;
        self.List = ko.mapping.fromJS(data);
    }   
    ko.applyBindings(new ClosedBusinessListModel);
});
