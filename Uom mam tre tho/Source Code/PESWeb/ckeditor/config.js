/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	config.toolbar = 'PES';

config.toolbar_PES =
[
    ['Source','-','Save','NewPage','Preview','-','Templates'],
    ['Cut','Copy','Paste','PasteText','PasteFromWord','-','Print', 'SpellChecker', 'Scayt'],
    ['Undo','Redo','-','Find','Replace','-','SelectAll','RemoveFormat'],
  ['Bold','Italic','Underline','Strike','-','Subscript','Superscript'],
   // '/',
    ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
    ['BidiLtr' 'BidiRtl'],
    ['NumberedList','BulletedList','-','Outdent','Indent','Blockquote','CreateDiv'],
    ['JustifyLeft','JustifyCenter','JustifyRight','JustifyBlock'],
    ['Link','Unlink','Anchor'],
    ['Image','Flash','Table','HorizontalRule','Smiley','SpecialChar','PageBreak'],
   // '/',
    ['Styles','Format','Font','FontSize'],
    ['TextColor','BGColor'],
    ['Maximize', 'ShowBlocks','-','About']
];
config.uiColor = '#bad3ed';
//,{extraPlugins : 'uicolor',uiColor: '#bad3ed',skin:'kama'}
//config.toolbar_full =
//[
    //['Source','-','Save','NewPage','Preview','-','Templates'],
    //['Cut','Copy','Paste','PasteText','PasteFromWord','-','Print', 'SpellChecker', 'Scayt'],
    //['Undo','Redo','-','Find','Replace','-','SelectAll','RemoveFormat'],
    //['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
    //['BidiLtr' 'BidiRtl'],
    //'/',
    //['Bold','Italic','Underline','Strike','-','Subscript','Superscript'],
    //['NumberedList','BulletedList','-','Outdent','Indent','Blockquote','CreateDiv'],
    //['JustifyLeft','JustifyCenter','JustifyRight','JustifyBlock'],
    //['Link','Unlink','Anchor'],
    //['Image','Flash','Table','HorizontalRule','Smiley','SpecialChar','PageBreak'],
    //'/',
    //['Styles','Format','Font','FontSize'],
    //['TextColor','BGColor'],
  //  ['Maximize', 'ShowBlocks','-','About']
//];
};
