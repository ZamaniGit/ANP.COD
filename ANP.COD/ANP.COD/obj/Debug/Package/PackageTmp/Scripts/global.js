



function CheckAll_Approved(chk) {

    all = document.getElementsByTagName('input');
    for (i = 0; i < all.length; i++) {
        if (all[i].type == 'checkbox' && all[i].id.indexOf('MyGrid') > -1 && all[i].id.indexOf('YES') > -1) {
            if (all[i].disabled == false)
                all[i].checked = chk.checked;
        }
    }
}
function RowsStyle() {
    $('#ctl07_MyGrid tr')
        .filter(':has(:checkbox:checked)')
        .addClass('selected')
        .end()
      .click(function (event) {
          $(this).toggleClass('selected');
          if (event.target.type != 'checkbox') {
              $(':checkbox', this).attr('checked', function () {
                  return !this.checked;
              });
          }
      });
  }

  function CheckedWithBarcodeReader(eventRef) {
      alert('hi');
      eventRef = (eventRef) ? eventRef : (event) ? event : (window.event) ? window.event : null;

      if (eventRef == null) {
          alert('eventRef == null');
          return true;
      }

      var keyCodePressed = (eventRef.which) ? eventRef.which : (eventRef.keyCode) ? eventRef.keyCode : -1;

      // Uncomment to see the keystrokes...
      //alert('keyCodePressed: ' + keyCodePressed + ' eventRef.ctrlKey: ' + eventRef.ctrlKey + ' eventRef.altKey: ' + eventRef.altKey);

      if ((eventRef.altKey) && (keyCodePressed == 40)) {
          alert('[ALT] + [Down arrow] pressed');
      }

      alert(eventRef.keyCode.toString());
      if (eventRef.keyCode == 13) {
          try {
              var Barcode = document.getElementById('ctl11$txtBarcodeSearch').value;
              var Grid;
              alert(Barcode.toString());

              if (document.getElementById('dgBarcodeListWithPostalCost') != null)
                  Grid = document.getElementById('dgBarcodeListWithPostalCost');

              else if (document.getElementById('dgBarcodeListWithOutPostalCost') != null)
                  Grid = document.getElementById('dgBarcodeListWithOutPostalCost');

              for (var index = 1; index < Grid.rows.length; index++)
                  if (Grid.rows[index].cells[2].innerHTML.toString() == Barcode) {
                      Grid.getElementById('chkSelect')[index].checked = true;
                      Grid.getElementsByTagName('input')[index].checked = true;
                  }
          }
          catch (e) {
              alert(e);
          }
          document.getElementById('ctl11_txtBarcodeSearch').value = '';
      }
  } 

function _CheckedWithBarcodeReader(e) 
    {
        if (e.keyCode === 13) 
        {
            try 
            {
                var Barcode = document.getElementById('ctl11_txtBarcodeSearch').value;
                var Grid = document.getElementById('MyGrid');
                for (var index = 1; index < Grid.rows.length; index++) 
                    if (Grid.rows[index].cells[2].innerHTML.toString() == Barcode) 
                        Grid.getElementsByTagName('input')[index].checked = true;
            }
            catch (e) 
            {
                alert(e);
            }
            document.getElementById('txtBarcodeReader').value = '';
        }
    }
  
  
