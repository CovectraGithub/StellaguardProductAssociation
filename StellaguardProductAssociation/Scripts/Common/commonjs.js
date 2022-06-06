/*!
 * commonjs.js
 * 
 * Description:
 *	this js is created to apply common functionality 
 *
 * Author:
 *	Virendra yadav
 *
 * Depends:
 *	jquery.js
 *	customevalidation.js
 *	jquery-validate.js
 *
 */
function Message(JSONObj)
{
	this.MessageVisible = false;
	this.IsGoodMessage = false;
	this.Message = "";
	if (JSONObj) 
	{
		if (JSONObj.hasOwnProperty("MessageVisible"))
			this.MessageVisible = JSONObj["MessageVisible"];
		if (JSONObj.hasOwnProperty("IsGoodMessage"))
			this.IsGoodMessage = JSONObj["IsGoodMessage"];
		if (JSONObj.hasOwnProperty("Message"))
			this.Message = JSONObj["Message"];
	}	
	return this;
}
(function ($) {

	// Apply all comman functionality to pages.
	defaults = {
		setfocusTo: "input[type=text]:first",

		isCounterUsed: false,
		counterTextBoxId: "#HRCodes",
		counterLabelId: "#count",

		loaderDivId: "#loaderDiv",
		redirectLocation: "#",

		myModal: "#myModal",
		myModalLabel: "#myModalLabel",
		customSummaryDiv: "#myCustomSummary",
		validationSummaryDiv: ".validsummary",
		defaultSummaryDiv: ".customsummary",

		isConfirmRequired: false,
		confirmText: "",
		duplicateError: "",
		notValidError: "",
		faliureError: "",
		serialNumberLength: "",
		HRCodeLength: "",
		Message: new Message(),
		ValidationSuccessCallBack: new function () { return true; },
		ValidationErrorCallBack: new function () { return true; }
	};

	$.ApplyCommonJs = function (options) {
	
		var settings = $.extend(true,{}, defaults,options);
		
		//code initialization starts from here 
				
		Initialize(settings);

	}

	$.ApplyCommonJs.GetDefaultOptions = function ()
	{
		var options = $.extend(true, {}, defaults);
		return options;
	}

	function Initialize(settings)
	{		
		SetFocus(settings);
		SetFocusInModalPopup(settings);
		ShowDefaultMessageInModalPopup(settings);
		if (settings.isCounterUsed)
		{
			SetCounter(settings);
		}
		
		$(settings.myModal + " button.closePopup").click(function (e) {
			CloseModal(settings);
			e.preventDefault();
		});				
		
		$(".validate-form").CheckValidation(settings,settings.ValidationSuccessCallBack, settings.ValidationErrorCallBack);
	}

	function SetFocus(settings)
	{
		$(settings.setfocusTo).focus();
	}

	function SetFocusInModalPopup(settings)
	{
		//add function for Modal Popup to set focus on button inside ModalPopup window 
		$(settings.myModal).on('shown.bs.modal',
			function () {
				setTimeout( //set timout used to wait for some time so the fade out animation of ModalPopup can run and after that this code performs
					function () {
						$(settings.myModal + ' button:nth-child(1)').focus();
					}
					, 50);
			});
	}

	function ShowDefaultMessageInModalPopup(settings)
	{		
		if (settings.Message.MessageVisible == true)
		{
			$(settings.myModal).modal('show');
		}
	}

	function SetCounter(settings) {
			
		var counterText = $(settings.counterTextBoxId).val();
		
		if (counterText != "" && counterText!=undefined) {
			var lbcount = checkCount(counterText);
			$(settings.counterLabelId).html(lbcount);
		} else {
			$(settings.counterLabelId).html("0");
		}

		$(settings.counterTextBoxId).keyup(
		function (e) {		

				var counterText = $(settings.counterTextBoxId).val();					
				if (counterText != "" && counterText != undefined) {
					var count = checkCount(counterText);
					$(settings.counterLabelId).html(count);
				}
				else {
					$(settings.counterLabelId).html("0");
				}
			
		});

		$(settings.counterTextBoxId).blur(
		function () {
			var counterText = $(settings.counterTextBoxId).val();
			if (counterText != "" && counterText != undefined) {
				var count = checkCount(counterText);
				$(settings.counterLabelId).html(count);
			}
			else {
				$(settings.counterLabelId).html("0");
			}
		});		
	}

	function CloseModal(settings)
	{
		SetFocus(settings);
	    $(settings.customSummaryDiv).html('');
	    $(settings.myModal).modal('hide');
	    if (settings.isGoodMessage && settings.messageText != "")
	    {
	        document.location = settings.redirectLocation;
	    }

	    return false;
	}
	
	$.fn.CheckValidation = function (options, successcallback, errorcallback)
	{

		var settings = $.extend({}, $.ApplyCommonJs.GetDefaultOptions(), options);
		
		var button = this;
		var form = button.closest("form");

		if (form != null && form != undefined)
		{
			$(button).click(function (e)
			{
				
				var button = this;

				$(settings.customSummaryDiv).html('');
				$(settings.validationSummaryDiv + ' ul').html('');
				
				if (form.valid())
				{
				
					var result = true;
					
					if ($.isFunction(successcallback))
					{
						result = successcallback.call(this,button);						
					}
					if (result)
					{
						$(settings.loaderDivId).modal("show");						
					}
					else
					{
						e.preventDefault();
						//prevent form posting
					}
				}
				else
				{
					if ($.isFunction(errorcallback))
					{
						errorcallback.call(this);
					}					
					
					$(settings.customSummaryDiv).html($(settings.validationSummaryDiv).html()); //Added for passing in partial view
					$(settings.validationSummaryDiv).hide(); //Added for clear from screen RJ
					$(settings.defaultSummaryDiv).hide();
					$(settings.myModal).modal('show');

					e.preventDefault();
				}
			});
		}
	};

	$.fn.ValidateHRCode = function (options)
	{
		var vars = $.extend({}, $.ApplyCommonJs.GetDefaultOptions(), options);

		var errorMessage = "";
		var validResult = true;

		var textbox = this;
		var serialNumbersStr = $(textbox).val();	

		if (serialNumbersStr == "")
		{
			return false;
		}
		
		var serialNumbersArray = getSerialNumberArray(serialNumbersStr);
		
		if (serialNumbersArray.length > 1)
		{
			ErrorMessage = "";
			validResult = DuplicateCheck(serialNumbersArray)
			
			if (validResult == false)
		    {
				errorMessage =vars.duplicateError + ErrorMessage;
			}
		}
		
		// Check for number is valid or not
		if (validResult == true)
		{		
			var length =vars.serialNumberLength;
			var pattern = '^(\\d{' + length + '}$)';
			var hrCodelength = vars.HRCodeLength;
		    var patt = new RegExp(pattern);
		
		    ErrorMessage = "";
		    validResult = CheckvalidHRCode(serialNumbersArray, patt, hrCodelength);
		
		    if (validResult == false)
		    {
				errorMessage =vars.notValidError + ErrorMessage;
			}
		}
		
		if (validResult)
		{
			$(vars.customSummaryDiv).empty();
		}
		else
		{
			$(vars.validationSummaryDiv).hide();
			$(vars.customSummaryDiv).empty();
			$(vars.customSummaryDiv).show();

		    $(vars.myModalLabel).html("");
		    $(vars.myModalLabel).html(vars.faliureError);

		    $(vars.customSummaryDiv).removeClass("SuccessMessage");
		    $(vars.customSummaryDiv).removeClass("validation-summary-errors");
		    $(vars.customSummaryDiv).addClass("validation-summary-errors");
		    $(vars.customSummaryDiv).append(errorMessage);

		    textbox.focus();

			$(vars.myModal).modal('show');		
		}

		return validResult;

	};
}(jQuery));
