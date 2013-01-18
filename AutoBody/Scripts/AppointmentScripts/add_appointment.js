$(document).ready(function () {

    $("#add_appointment").click(function () {

        var appointments_count = 0;

        $("div[id^='appointment']").each(function (index, element)
        {
            appointments_count++;
        });
        
        if (appointments_count > 2) {
            alert("3 Appointments is enough data for one API call...");
            return;
        }

        var appt_index = appointments_count - 1;
        var $newAppt = $("#appointment0").clone(true);
        $newAppt.find('*').each(function (i, e) {
            var id = $(e).attr("id");
            if (typeof id != "undefined")
                $(e).attr("id", id.replace("Appointments_0", "Appointments_" + appointments_count));

            var name = $(e).attr("name");
            if (typeof name != "undefined")
                $(e).attr("name", name.replace("Appointments[0", "Appointments[" + appointments_count));
        });
        $newAppt.attr("id", "appointment" + appointments_count);
        $newAppt.insertAfter($("#appointment" + appt_index));

        $("div[data-role='collapsible-set']").each(function(index, element) {
            var $temp = $(element);
            $(element).remove();
            $("#wrap_appointments").append($temp);

            $(element).find("a").remove();
        });

        $("ul[data-role=collapsible]").collapsible();
        $("ul[data-role=collapsible]").find(".ui-btn-text").html("Appointment");

        $("input[name='appointmentsCount']").val((appointments_count+1).toString());
    });
    
    $("input[name='appointmentsCount']").val("1");
    


});