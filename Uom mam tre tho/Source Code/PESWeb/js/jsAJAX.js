// JScript File
var XHR; //XHR = XMLHttpRequest.
/** CREATE XMLHTTPREQUEST*/

function createXHR()
{
    if (window.XMLHttpRequest)
        XHR = new XMLHttpRequest();//With Mozilla, Nescape, ...
    else
        if (window.ActiveXObject)
            XHR = new ActiveXObject("Microsoft.XMLHTTP");
}


/*
    ProductID: ID Sản phẩm.
    ShopID: ID Shop.
    MainDivID: ID của DIV Cart Tag.
    DivID: ID hiển thị số lượng Item trong Cart.
    Url: Đường dẫn trang xử lý dữ liệu trên Server.
*/
function AddProductToCart(ProductID, ShopID, MainDivID, DivID, Url) {
    //debugger;
    createXHR();
    
    if(XHR == null)
    {
        HideDiv(MainDivID);
    }
    else
    {
        ShowDiv(MainDivID);

        var par;

        par = "ProductID=" + ProductID + "&ShopID=" + ShopID;
        
        var objDiv = document.getElementById(DivID);
                       
        XHR.open("POST", Url, true);
        XHR.onreadystatechange = function()
        {
            if(XHR.readyState != 4)
            {
                objDiv.innerHTML = "<img style='padding-top: 22px; padding-left: 5px;' src = 'Design/Imgs/imgLoading.gif' alt = ''/>";
            }
            else
                {
                    if(XHR.status == 200)
                    {
                        objDiv.innerHTML = XHR.responseText;                   
                    }
                    else
                    {
                        objDiv.innerHTML = "Lỗi";
                        HideDiv(MainDivID);
                    }
                }
        }
        XHR.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
        XHR.setRequestHeader("Content-length", par.length);
        XHR.setRequestHeader("Connection", "close");
        XHR.send(par);
    }    
}

function ShowDiv(DivID)
{
    //Show hide.                
    if (document.getElementById) 
    { // DOM3 = IE5, NS6
        document.getElementById(DivID).style.display = 'block';
    }
    else 
    {
        if (document.layers) 
        { // Netscape 4
            document.DivID.display = 'block';
        }
        else 
        { // IE 4
            document.all.DivID.style.display = 'block';
        }
    }
}      


function HideDiv(DivID)
{
    if (document.getElementById) 
    { // DOM3 = IE5, NS6
        document.getElementById(DivID).style.display = 'none';
    }
    else 
    {
        if (document.layers) 
        { // Netscape 4
            document.DivID.display = 'none';
        }
        else 
        { // IE 4
            document.all.DivID.style.display = 'none';
        }
    }
}