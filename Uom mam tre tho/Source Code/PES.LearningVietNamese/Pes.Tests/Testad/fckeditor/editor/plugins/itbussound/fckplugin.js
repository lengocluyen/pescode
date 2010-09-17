var ITBusSound = function(){};
ITBusSound.GetState=function() {
return FCK_TRISTATE_OFF;
}
ITBusSound.Execute=function() {
window.open('plugins/itbussound/itbussound.htm', 'itbussound', 'width=600,height=400,scrollbars=no,scrolling=no,location=no,toolbar=no');
}
FCKCommands.RegisterCommand('itbussound', ITBusSound ); //otherwise our command will not be found
var oITBusSound = new FCKToolbarButton('itbussound', 'Chèn âm thanh');
oITBusSound.IconPath = FCKConfig.PluginsPath + 'itbussound/itbussound.ico'; //specifies the image used in the toolbar
FCKToolbarItems.RegisterItem( 'itbussound', oITBusSound );
