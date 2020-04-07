/* Web Experience Toolkit (WET) / Bo�te � outils de l'exp�rience Web (BOEW)
Terms and conditions of use: http://tbs-sct.ircan.gc.ca/projects/gcwwwtemplates/wiki/Terms
Conditions r�gissant l'utilisation : http://tbs-sct.ircan.gc.ca/projects/gcwwwtemplates/wiki/Conditions
*/

/** Change Log
* 2010.05.21 - Laurent Goderre - Port of CRA jQuery Plugin and rewrite
* 2010.05.21 - Mario Bonito - Request CRA.1 - Add the ability to have a placeholder for the Show/Hide All 
* 2010.05.21 - Mario Bonito - Optimization TC.1 - Decreased memory load, and improved performance by adding object scoped dictionary for english and french text 
* 2010.05.21 - Mario Bonito - Normalization TC.2 - Normalized all speed of effects to 'normal' as part of best practices for Photosensitive epilepsy 
* 2010.05.21 - Mario Bonito - Integration TC.3 - Integration of both menu and content expand and hide functionality 
* 2010.05.26 - Mario Bonito - Integration CRA.1.1 - Increase the capacity of the global controls to contain more than one instance 
* 2010.05.26 - Mario Bonito - Integration CRA.1.2 - Added menu specific dictionary text to allow for more granular control over menu and content Show/Hide All text
* 2010.05.26 - Mario Bonito - Integration CRA.1.3 - Modified default behaviour to create consistent place holder containers for all instance of the Show/Hide
* 2010.05.26 - Mario Bonito - Integration CRA.1.4 - Standardized all controls class output
* 2010.06.24 - Mario Bonito - Core Working Group feedback UxWG.1.0 - Hide the expand/hide autogenerated text, and hid the link text.
* 2010.08.08 - Paul Jackson - Added WAI-ARIA support
* 2011.01.11   - Laurent Goderre - Added ability functionality to save the state of expand/hide boxes
* 2011.01.12   - Laurent Goderre - Added a parameter to control saving the state of the expand/hide boxes. Default now set to not save.
**/ 
var expandhide = {
	params :  Utils.loadParamsFromScriptID("expandhide"),
	cookie_name :  "expandhide-",
	
	dictionary : { //[TC.1 - Dictionary Object Created
		hideText :(PE.language == "eng") ? "Hide:" : "Masquer :",
		hideMenuText :(PE.language == "eng") ? "hide" : "masquer",
		hideAllText: (PE.language == "eng") ? "Hide All<span class=\"cn-invisible\"> sections of collapsable content</span>" : "Masquer Tout<span class=\"cn-invisible\">es les sections de contenu rabatable</span>",
		expandText : (PE.language == "eng") ?  "Expand:" : "Afficher :",
		expandMenuText : (PE.language == "eng") ?  "expand" : "afficher",
		expandAllText: (PE.language == "eng") ? "Expand All<span class=\"cn-invisible\"> sections of collapsed content</span>" : "Afficher Tout<span class=\"cn-invisible\">es les sections masqu\xe9es</span>" 
        },
	
	init : function(){
		// Create the cookie name
		if (this.params.cookie_scope != null) {
			if (this.params.cookie_scope == "domain") this.cookie_name += window.location.host;
			else if (this.params.cookie_scope == "query") this.cookie_name += window.location.host + window.location.pathname + window.location.search;
			else this.cookie_name += window.location.host + window.location.pathname;
		} else {
			this.cookie_name += window.location.host + window.location.pathname;
		}
		
		if (this.params.cookie_expires == null || isNaN(this.params.cookie_expires)) {
			this.params.cookie_expires = 365;
		}else{
			this.params.cookie_expires = parseInt(this.params.cookie_expires);
		}
		
		if (this.params.saveStates == null){
			this.params.saveStates = false;
		}
		
		if (this.params.globalToggles == true || this.params.globalToggles == "true"){
			var globalidentifiers = []
			if ( $('.toggle-all-controls').length ) {
				$('.toggle-all-controls').each(function() {
					expandhide.addGlobalTriggers($(this), false); // [CRA.1.1 - Increased capacity to handle more than one iteration of a control placer]
				});
			} else {
				expandhide.addGlobalTriggers($("<div class=\"toggle-all-controls\"></div>"),true);
			}  
		}
		this.addTriggers();
        
		/** Special Overide - CRA REQUEST **/
		if(expandhide.params.rule == 'enforce-nav-open') {
			$("div#cn-left-col ul > li:has(ul)").addClass('nav-open');
			$("ul.toggle-menu").parent("ul > li").removeClass('nav-open');
		}
	},
	
	addTriggers : function(){
		var currIndexTC = 1;
		var idPrefixTC = 'toggle-content-id';
		var ariaControls = '';
		var currIndexTM = 1;
		var idPrefixTM = 'toggle-menu-id';
	    
		if (expandhide.params.titleSelector == undefined || expandhide.params.titleSelector == ''){
			expandhide.params.titleSelector = ':header:eq(0)';
		}
	    
		$('.toggle-content, .toggle-menu').each(function(e){
			if ($(this).is('.toggle-content'))
			{
				if ($(this).attr('id').length == 0) {
					$(this).attr('id',idPrefixTC + currIndexTC);
					if (currIndexTC == 1) ariaControls = ariaControls + idPrefixTC + currIndexTC;
					else ariaControls = ariaControls + ' ' + idPrefixTC + currIndexTC;
					currIndexTC++;
				}
			} else {
				if ($(this).attr('id').length == 0) {
					$(this).attr('id',idPrefixTM + currIndexTM);
					currIndexTM++;
				}
			}
		});
		
		expandhide.loadStates();
		
		$('.toggle-content').each(function(e){
			expandhide.createContentControl(this);
		});
		
		$('.toggle-menu').each(function(e){
			expandhide.createMenuControl(this);
		});
		
		if (currIndexTC > 1) {
			$('.toggle-all-expand').attr('aria-control',ariaControls);
			$('.toggle-all-collapse').attr('aria-control',ariaControls);
		}
	},
	
	// TC.3 - Since there are two potential classes that have different childern selectors and mechanics seperate object based methods were created.
	//  - Method : createContentControl - Creates the Content body expand/hide functionality
	createContentControl: function(elm) {
                var content = $(elm);
                var toggleContainer = $("<div></div>");
                var titleText = content.children(expandhide.params.titleSelector).text();
	    
                content.children(expandhide.params.titleSelector).addClass('cn-invisible'); // UxWG Request to remove duplicate Head elements
                var initText; var initClass;
                if (content.hasClass('collapse')){
			content.hide().attr('aria-hidden','true');
			initText = expandhide.dictionary.expandText;
			initClass="toggle-link-expand";
                } else{
			content.attr('aria-hidden','false')
			initText = expandhide.dictionary.hideText;
			initClass="toggle-link-collapse";
                }
                var toggle = $("<a class=\"" + initClass + "\" href=\"javascript:;\" role=\"button\" aria-pressed=\"" +( (content.hasClass('collapse')) ? 'false' : 'true')+ "\" aria-controls=\"" + content.attr('id') + "\"><span class=\"cn-invisible "+( (content.hasClass('collapse')) ? 'state-expand' : 'state-hide')+"\">" + initText + "</span> " + titleText + "</a>");
                
                toggle.click(function(){expandhide.toggle(this);});
                toggleContainer.append(toggle);
                content.before(toggleContainer);
	},
	
	// TC.3 - Since there are two potential classes that have different childern selectors and mechanics seperate object based methods were created.
	//  - Method : createMenuControl - Creates the Ul Meun based expand/hide functionality
	createMenuControl: function(elm) {
		var element = $(elm);
		element.hide();
		element.prev().addClass('toggle-menu-spacer'); // dynamenu-spacer => toggle-menu-spacer
		var tText = element.parent().find(expandhide.params.titleSelector).text() ;
		/** Add Arrow **/
		element.before("<a class=\"toggle-menu-link-expand\" href=\"javascript://\" role=\"button\" aria-pressed=\"false\" aria-controls=\"" + element.attr('id') + "\">"+expandhide.dictionary.expandMenuText+" <span class=\"cn-invisible\">"+tText+"</span></a>");
		element.addClass('toggle-menu-collapse').attr('aria-hidden','true');
		/** Now add the toggle level **/
		element.prev().click(
		function() {
			$(this).next().slideToggle('normal');
			var tText = $(this).parent().find(expandhide.params.titleSelector).text() ;
                 
			if ( $(this).next().hasClass('toggle-menu-collapse') ) {
				$(this).html( expandhide.dictionary.hideMenuText +" <span class=\"cn-invisible\">"+tText+"</span>");
				$(this).removeClass('toggle-menu-link-expand');
				$(this).addClass('toggle-menu-link-collapse').attr('aria-pressed','true');
				$(this).parent().addClass('nav-open');
				$(this).next().removeClass('toggle-menu-collapse').attr('aria-hidden','false');  
			}else{ 
				$(this).html( expandhide.dictionary.expandMenuText+" <span class=\"cn-invisible\">"+tText+"</span>");
				$(this).removeClass('toggle-menu-link-collapse');
				$(this).addClass('toggle-menu-link-expand').attr('aria-pressed','false');
				$(this).parent().removeClass('nav-open');
				$(this).next().addClass('toggle-menu-collapse').attr('aria-hidden','true');                 
			}
		}
            );
            /** Special Overide - CRA REQUEST **/
            /** if(expandhide.params.rule == 'enforce-nav-open') {
                $("ul").parent("ul > li").addClass('nav-open');
                $("ul.toggle-menu").parent("ul > li").removeClass('nav-open');
                }    **/
	},
    
	addGlobalTriggers : function(elm, wflag){  
		var toggleAllContainer = $(elm); // [CRA.1 - Added conditional so that optional 'toggle-all-controls' class could be used to place the expand all controls if present]
        
        
		var toggleShowAll = $("<a class=\"toggle-all-expand\" href=\"javascript:;\"><span>" + expandhide.dictionary.expandAllText+ "</span></a>");
		toggleShowAll.attr('role','button').click(function(){expandhide.showAll(this);});
		var toggleHideAll = $("<a class=\"toggle-all-collapse\" href=\"javascript:;\"><span>" + expandhide.dictionary.hideAllText+ "</span></a>");
		toggleHideAll.attr('role','button').click(function(){expandhide.hideAll(this);});
		toggleAllContainer.append(toggleShowAll).append(toggleHideAll);
		if ( wflag ) { $('.toggle-content:first').before(toggleAllContainer) }; //[CRA.1 - made the default behaviour of adding the controls to the top of the first instance of the toggle content an optional trigger]
	},
    
	toggle : function(obj){
		var toggle = $(obj);
		var toggleContent = toggle.parent().next('.toggle-content:first');
		toggleContent.slideToggle('normal', function(){expandhide.saveStates()});
		if (toggleContent.attr('aria-hidden') == 'false') toggleContent.attr('aria-hidden','true');
		else toggleContent.attr('aria-hidden','false');
		toggle.toggleClass("toggle-link-expand toggle-link-collapse");
		this.toggleText(toggle);
	},
	
	showAll : function (){
		$('.toggle-content').slideDown('normal', function(){expandhide.saveStates()}).attr('aria-hidden','false');
		var toggles = $('.toggle-link-expand');
		toggles.removeClass().addClass('toggle-link-collapse');
		toggles.each(
			function(){expandhide.toggleText($(this));}
		)
	},
	
	hideAll : function (){
		$('.toggle-content').slideUp('normal', function(){expandhide.saveStates()}).attr('aria-hidden','true');
		var toggles = $('.toggle-link-collapse');
		toggles.removeClass().addClass('toggle-link-expand');
		toggles.each(
			function(){expandhide.toggleText($(this));}
		)
	},
	
	cleanseText : function(str) {
		var re = /^([^:]*):(.+)$/;
		var output = str.replace(re, '$2');
		return output;
	},
	
	toggleText : function(toggle){
		if ( $(toggle).find('span').hasClass('state-expand') ){
			$(toggle).find('span').removeClass('state-expand').addClass('state-hide').text(this.dictionary.hideText);
			$(toggle).attr('aria-pressed','true');
		}else{
			$(toggle).find('span').removeClass('state-hide').addClass('state-expand').text(this.dictionary.expandText);
			$(toggle).attr('aria-pressed','false');
		}
	},
	
	saveStates: function(){
		if (this.params.saveStates != false && this.params.saveStates != 'false'){
			var cookie = ""
			$('.toggle-content').each(function(){
				cookie += $(this).attr("id") + ":" +  !$(this).is(":hidden") + ","
			});
			$.cookie(this.cookie_name, cookie.substr(0, cookie.length-1), { expires: this.params.cookie_expires});
		}
	},
	
	loadStates : function(){
		if (this.params.saveStates != false && this.params.saveStates != 'false'){
			var cookie = $.cookie(this.cookie_name);
			
			//Resets the expiring date
			$.cookie(this.cookie_name, cookie, { expires: this.params.cookie_expires});
			
			if (cookie != null){
				var positions = cookie.split(',');
				for(p = 0; p< positions.length;p++){
					
					var parts = positions[p].split(':')
					
					var obj = $('#' + parts[0]);
					if (obj.hasClass('collapse') && parts[1] == 'true'){
						obj.removeClass('collapse');
					}else if(!obj.hasClass('collapse') && parts[1] == 'false'){
						obj.addClass('collapse');
					}
				}
			}
		}
	}
}

PE.load('jquery.cookie.js');

// Add Style Sheet Support for this plug-in
Utils.addCSSSupportFile(Utils.getSupportPath()+"/expandhide/style.css"); 
// Init Call at Runtime
$("document").ready(function(){   expandhide.init(); });