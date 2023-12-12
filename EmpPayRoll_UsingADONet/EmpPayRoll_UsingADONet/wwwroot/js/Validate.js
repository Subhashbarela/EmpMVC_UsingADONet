function validateJoiningDate()
{
    var date = new Date($('.joiningDate').val());  
    var currentDate = new Date();

    currentDate.setHours(0, 0, 0, 0);

    if (date < currentDate) {
        alert("Please select a future date for joining ");
        date.value = "";
    }

}