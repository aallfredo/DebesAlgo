﻿
$.get("/ClosedBusiness", function (data) {
    
    function ClosedBusinessListModel()
    {
        var self = this;
        self.Data = ko.mapping.fromJS(data);
    }   
    ko.applyBindings(new ClosedBusinessListModel);
});
