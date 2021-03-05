$(document).ready(function() {	
	$('#cantidadId').on('keyup',  function() {
		var cant=$(this).val();
        var precio=$('#precio')
        $('#subTotalId').val(cant*precio);
	});
});
