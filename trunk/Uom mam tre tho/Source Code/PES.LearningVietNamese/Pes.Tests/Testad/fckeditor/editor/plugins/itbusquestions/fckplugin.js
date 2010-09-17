var ITBusQuestion = function(){};
ITBusQuestion.GetState=function() {
return FCK_TRISTATE_OFF;
}
ITBusQuestion.Execute=function() {
window.open('plugins/itbusquestions/ask.htm', 'itbusquestions', 'width=300,height=350,scrollbars=yes,scrolling=no,location=no,toolbar=no');
}
FCKCommands.RegisterCommand('itbusquestions', ITBusQuestion ); //otherwise our command will not be found
var oITBusQuestion = new FCKToolbarButton('itbusquestions', 'Đặt Câu Hỏi');
oITBusQuestion.IconPath = FCKConfig.PluginsPath + 'itbusquestions/ask.ico'; //specifies the image used in the toolbar
FCKToolbarItems.RegisterItem( 'itbusquestions', oITBusQuestion );
