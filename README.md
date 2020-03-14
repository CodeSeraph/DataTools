## DataTools NuGet Package

<span id='contents'>

1. [Overview](#1)
2. [Namespace and Instantiation](#2)
3. [Methods](#3)

</span>

<a name='1' style="padding-top: 50px">

### Overview

- The Data Tools package provides is simple and easy to use set of commone extensions and methods to make tasks quicker and easier to perform.
- Minimum Target Framework: 4.6.1

<a name='2' style="padding-top: 50px">

### Namespace and Instantiation

- The namespace for the classes is DataTools and will need to be referenced in your project after installing the NuGet package.
    ```C#
    using DataTools;
    ```

<a name='3' style="padding-top: 50px">

### Bool Extensions Methods

#### ConvertToYN()
- This will convert a bool value to either Y or N string.
    ``` C#
    bool value = true;
    string stringval = value.ConvertToYN();
    //result = Y
    ```

#### ConvertToYesNo()
- This will convert a bool value to either Yes or No string.
    ``` C#
    bool value = true;
    string stringval = value.ConvertToYesNo();
    //result = Yes
    ```

### Form Extensions Methods

#### Get<T>()
- This is an extension for the PlaceHolder control.
- This will find and return a control contained within the PlaceHolder control.
- This is particularly useful if you are using the FormBuilder.
- T is type class.
    ``` C#
    PlaceHolder holder = new PlaceHolder();
    holder.Add(new Label(){ ID = "namelbl"});

    var control = holder.Get<Label>("namelbl");    
    ```

#### ClearControls()
- This is an extension for the System.Web.UI control.
- This will clear all textboxes, checkboxes, dropdownlists and radiobutton lists within the control.
    ``` C#
    PlaceHolder holder = new PlaceHolder();
    holder.ClearControls();
    ```

#### RenderControlToHtml()
- This is an extension for the System.Web.UI control.
- This will render a control down to html server side.
    ``` C#
    TextBox textbox = new TextBox();
    textbox.RenderControlToHtml();
    ```

### String Extensions Methods

#### RoundNumeric()
- This will convert a string to decimal round the value to a specific number of decimal places and return it as a string.
    ``` C#
    string value = "100.7689";
    string result = value.RoundNumeric(2);
    //result = "100.77"
    ```

#### HtmlEncode()
- This will encode special characters
    ``` C#
    string value = "<p>your text</p>";
    string result = value.HtmlEncode();
    //result = "&lt;p&gt;your text&lt;/p&gt;"
    ```

#### HtmlDecode()
- This will decode special characters
    ``` C#
    string value = "&lt;p&gt;your text&lt;/p&gt;";
    string result = value.HtmlDecode();
    //result = "<p>your text</p>"
    ```

#### RemoveSpecialCharacters()
- This will remove special characters from a string including: `,$\()&%#!*+=`

#### HashValue()
- This will hash any string value

#### StandardizeText()
- This will standardize text to be all sentence case

#### Base64Encode()
- This will base64 encode any string

#### Base64Decode()
- This will decode any base64 encoded string

#### ShortenText()
- This will shorten a string to a specific length.
    ``` C#
    string value = "some text goes here";
    string result = value.ShortenText(10);
    //result = "some text ..."
    ```

#### RemoveHTMLTags()
- This will remove html tags
    ``` C#
    string value = "<p>your text</p>";
    string result = value.RemoveHTMLTags();
    //result = "your text"
    ```

#### ConvertToEnum()
- This will convert a string value to an enum
    ``` C#
    public enum Status
    {
        Complete,
        Pending,
        OnHold
    }

    string value = "Pending";
    Status result = value.ConvertToEnum<Status>();
    //result = Status.Pending
    ```

#### ToCurrency()
- This will convert a string value to currency 
- ToCurrency has the following overloads:
    - `ToCurrency(this String value, string currencysymbol)`
    - `ToCurrency(this String value, string currencysymbol, int decimalplaces)`
    - `ToCurrency(this String value, string currencysymbol, int decimalplaces, string groupseperator)`
    - `ToCurrency(this String value, string currencysymbol, int decimalplaces, string groupseperator, string decimalseparator)`
    - `ToCurrency(this String value, string currencysymbol, int decimalplaces, string groupseperator, string decimalseparator, int currencynegativepattern)`


#### YesNoToBool()
- This will convert a bool value to either Yes or No string.
    ``` C#
    string value = "Yes";
    bool boolval = value.YesNoToBool();
    //result = true
    ```

#### YNToBool()
- This will convert a bool value to either Y or N string.
    ``` C#
    string value = "Y";
    bool boolval = value.YNToBool();
    //result = true
    ```

### Numeric Methods

#### Percentage() Method
- This will calculate the percentage of 2 values as a decimal and has the following overloads:
    - `Percentage(string numerator, string denominator)`
    - `Percentage(double numerator, double denominator)`
    - `Percentage(decimal numerator, decimal denominator)`
    - `Percentage(int numerator, int denominator)`

#### ConvertZeroToDash() Extension Method
- This will convert 0 to - and has the following overloads:
    - `ConvertZeroToDash(this double value)`
    - `ConvertZeroToDash(this decimal value)`
    - `ConvertZeroToDash(this int value)`
    - `ConvertZeroToDash(this String value)`

### Password Methods

#### Random()
- This will generate a random password.
    ``` C#
    string value = Password.Random();
    string value = Password.Random(10); //Generate a password of length 10
    ```
