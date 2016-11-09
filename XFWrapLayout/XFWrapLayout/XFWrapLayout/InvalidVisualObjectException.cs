using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XFWrapLayout
{
#pragma warning disable CS1574
    // XML comment has cref attribute that could not be resolved
    /// <summary>
    /// Thrown when datatemplate inflates to an object 
    /// that is neither a <see cref="Xamarin.Forms.View"/> object nor a
    /// <see cref="Xamarin.Forms.ViewCell"/> object
    /// </summary>
    public class InvalidVisualObjectException : Exception
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
    {
        /// <summary>
        /// Hide any possible default constructor
        /// Redundant I know, but it costs nothing
        /// and communicates the design intent to
        /// other developers.
        /// </summary>
        private InvalidVisualObjectException() { }

        /// <summary>
        /// Constructs the exception and passes a meaningful
        /// message to the base Exception
        /// </summary>
        /// <param name="inflatedtype">The actual type the datatemplate inflated to.</param>
        /// <param name="name">The calling methods name, uses [CallerMemberName]</param>
        public InvalidVisualObjectException(Type inflatedtype, [CallerMemberName] string name = null) :
            base(string.Format("Invalid template inflated in {0}. Datatemplates must inflate to Xamarin.Forms.View(and subclasses) "
                               + "or a Xamarin.Forms.ViewCell(or subclasses).\nActual Type received: [{1}]", name, inflatedtype.Name))
        { }
        /// <summary>
        /// The actual type the datatemplate inflated to.
        /// </summary>
        public Type InflatedType { get; set; }
        /// <summary>
        /// The MemberName the exception occured in.
        /// </summary>
        public string MemberName { get; set; }
    }
}
