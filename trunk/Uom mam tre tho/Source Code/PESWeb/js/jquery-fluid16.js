var fluid = {
Ajax : function(){ 
    jQuery("[id$='ajax']").each(function() {
	    var $this = jQuery(this);
	    var href = $this.attr("href");
    	var toggle = this.id.match(/^toggle/);      					
		var content = toggle ? this.id.substr(7) : this.id;
		var loading = jQuery("#" + content + "-loading");
		if(loading.length==0)
			loading = jQuery("#loading");
		content = jQuery("#"+content+"-ctn");
		if(href.length && content.length){
			loading.hide();
			if(toggle){
				content.hide();
				$this.bind("click", function(e) {	        
				    if ($this.is(".hidden") ) {
					    loading.show();
			            content.empty();					
			            content.load(href, function() {
			            	loading.hide();
			            	content.slideDown();
			            });
			        }
			        else {
			            content.slideUp();
			        }	
			     	if ($this.hasClass('hidden')){
			            $this.removeClass('hidden').addClass('visible');	
			        }
			        else {
			            $this.removeClass('visible').addClass('hidden');
			        } 
			       	e.preventDefault();
		    	});
			}
			else{
				$this.bind("click", function(e) {
			        content.empty();
			        loading.show();
		            content.load(this.href, function() {
		            	loading.hide();
		            	content.fadeIn();
		            });
                   	e.preventDefault();
		    	});
			}
		}
	});		
 },
Toggle : function(){
	jQuery("[id^='toggle']").each(function(){
		var id=this.id.substr(7);
		if(id.length && !id.match(/ajax$/)){
			var $this = jQuery(this);
			var el = jQuery("#" + id);
			if($this.hasClass('hidden'))
				el.hide();
			$this.bind("click", function(e) {
				if ($this.hasClass('hidden')){
					$this.removeClass('hidden').addClass('visible');
					el.slideDown();
				} else {
					$this.removeClass('visible').addClass('hidden');
					el.slideUp();
				}
				e.preventDefault();
			});
		}
	});

},
Kwicks : function(){
	var animating = false;
    jQuery("#kwick .kwick")
        .bind("mouseenter", function(e) {
            if (animating) return false;
            animating == true;
            jQuery("#kwick .kwick").not(this).animate({ "width": 125 }, 200);
            jQuery(this).animate({ "width": 485 }, 200, function() {
                animating = false;
            });
        });
    jQuery("#kwick").bind("mouseleave", function(e) {
        jQuery(".kwick", this).animate({ "width": 215 }, 200);
    });
},
SectionMenu : function(){
	jQuery(".section-menu")
        .accordion({
            "header": "a.menuitem"
        })
        .bind("accordionchangestart", function(e, data) {
            data.newHeader.next().andSelf().addClass("current");
            data.oldHeader.next().andSelf().removeClass("current");
        })
        .find("a.menuitem:first").addClass("current")
        .next().addClass("current");
},
Accordion: function(){
	jQuery(".accordion").accordion({
        'header': "h3.atStart"
    }).bind("accordionchangestart", function(e, data) {
        data.newHeader.css({
            "font-weight": "bold",
            "background": "#fff"
        });

        data.oldHeader.css({
            "font-weight": "bold",
            "background": "#EEF1F6"
        });
    }).find("h3.atStart:first").css({
        "font-weight": "bold",
        "background": "#fff"
    });
}
}

jQuery(function($) {
	//if(jQuery(".accordion").length){fluid.Accordion();}
	//if(jQuery("[id$='ajax']").length){fluid.Ajax();}
	//if(jQuery("[id^='toggle']").length){fluid.Toggle();}
	//if(jQuery("#kwick .kwick").length){fluid.Kwicks();}
	//if(jQuery(".section-menu").length){fluid.SectionMenu();}

	fluid.Accordion();
	fluid.Ajax();
	fluid.Toggle();
	fluid.Kwicks();
	fluid.SectionMenu();

});
