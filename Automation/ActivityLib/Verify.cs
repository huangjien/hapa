﻿using System.Activities;
using System.Xml.Linq;


namespace ActivityLib
{
    //[ToolboxBitmap(typeof(Click),"Resources.Click.bmp"]
    public class Verify : LeafAction
    {
        // Define an activity input argument of type string

        public InArgument<string> Feature { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(NativeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
        }

        //public override XElement SetData(ActivityContext context, DataContext currentDataContext)
        //{
        //    //UIObject is the name of the object we want to click, we store it in the currentDataContext
        //    //get its value at runtime, then we can set our Xelement at this moment
        //    var xContent = new XElement("Verify",
        //                                new XAttribute(ConstString.AttributeId, Id),
        //                                new XAttribute("InstanceId", InstanceId),
        //                                new XAttribute("Feature", Feature.Get<string>(context))
        //        );
        //    XElement guiObject = FindGuiObjectInDataContext(UIObject);

        //    xContent.Add(guiObject);
        //    return xContent;
        //}
    }
}