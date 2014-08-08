using System.ComponentModel;

namespace System.Drawing
{
    public interface IBounds
    {
        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Location"]/*' /> 
        /// <devdoc>
        ///    <para>
        ///       Gets or sets the coordinates of the
        ///       upper-left corner of the rectangular region represented by this <see cref='System.Drawing.Rectangle'/>. 
        ///    </para>
        /// </devdoc> 
        [Browsable(false)]
        Point Location
        {
            [System.Runtime.TargetedPatchingOptOutAttribute("Performance critical to inline across NGen image boundaries")]
            get;
            [System.Runtime.TargetedPatchingOptOutAttribute("Performance critical to inline across NGen image boundaries")]
            set;
        }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Size"]/*' />
        /// <devdoc>
        ///    Gets or sets the size of this <see cref='System.Drawing.Rectangle'/>. 
        /// </devdoc>
        [Browsable(false)]
        Size Size
        {
            [System.Runtime.TargetedPatchingOptOutAttribute("Performance critical to inline across NGen image boundaries")]
            get;
            [System.Runtime.TargetedPatchingOptOutAttribute("Performance critical to inline across NGen image boundaries")]
            set;
        }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.X"]/*' />
        /// <devdoc>
        ///    Gets or sets the x-coordinate of the
        ///    upper-left corner of the rectangular region defined by this <see cref='System.Drawing.Rectangle'/>. 
        /// </devdoc>
        int X { get; set; }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Y"]/*' /> 
        /// <devdoc> 
        ///    Gets or sets the y-coordinate of the
        ///    upper-left corner of the rectangular region defined by this <see cref='System.Drawing.Rectangle'/>. 
        /// </devdoc>
        int Y { get; set; }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Width"]/*' />
        /// <devdoc>
        ///    Gets or sets the width of the rectangular 
        ///    region defined by this <see cref='System.Drawing.Rectangle'/>.
        /// </devdoc> 
        int Width { get; set; }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Height"]/*' /> 
        /// <devdoc>
        ///    Gets or sets the width of the rectangular 
        ///    region defined by this <see cref='System.Drawing.Rectangle'/>.
        /// </devdoc>
        int Height { get; set; }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Left"]/*' />
        /// <devdoc> 
        ///    <para>
        ///       Gets the x-coordinate of the upper-left corner of the 
        ///       rectangular region defined by this <see cref='System.Drawing.Rectangle'/> . 
        ///    </para>
        /// </devdoc> 
        [Browsable(false)]
        int Left { get; }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Top"]/*' /> 
        /// <devdoc>
        ///    <para> 
        ///       Gets the y-coordinate of the upper-left corner of the
        ///       rectangular region defined by this <see cref='System.Drawing.Rectangle'/>.
        ///    </para>
        /// </devdoc> 
        [Browsable(false)]
        int Top { get; }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Right"]/*' />
        /// <devdoc> 
        ///    <para>
        ///       Gets the x-coordinate of the lower-right corner of the 
        ///       rectangular region defined by this <see cref='System.Drawing.Rectangle'/>. 
        ///    </para>
        /// </devdoc> 
        [Browsable(false)]
        int Right
        {
            [System.Runtime.TargetedPatchingOptOutAttribute("Performance critical to inline across NGen image boundaries")]
            get;
        }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Bottom"]/*' /> 
        /// <devdoc>
        ///    <para>
        ///       Gets the y-coordinate of the lower-right corner of the
        ///       rectangular region defined by this <see cref='System.Drawing.Rectangle'/>. 
        ///    </para>
        /// </devdoc> 
        [Browsable(false)]
        int Bottom
        {
            [System.Runtime.TargetedPatchingOptOutAttribute("Performance critical to inline across NGen image boundaries")]
            get;
        }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.IsEmpty"]/*' /> 
        /// <devdoc> 
        ///    <para>
        ///       Tests whether this <see cref='System.Drawing.Rectangle'/> has a <see cref='System.Drawing.Rectangle.Width'/> 
        ///       or a <see cref='System.Drawing.Rectangle.Height'/> of 0.
        ///    </para>
        /// </devdoc>
        [Browsable(false)]
        bool IsEmpty { get; }

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Equals"]/*' /> 
        /// <devdoc>
        ///    <para> 
        ///       Tests whether <paramref name="obj"/> is a <see cref='System.Drawing.Rectangle'/> with 
        ///       the same location and size of this Rectangle.
        ///    </para> 
        /// </devdoc>
        bool Equals(object obj);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Contains"]/*' /> 
        /// <devdoc>
        ///    <para> 
        ///       Determines if the specfied point is contained within the 
        ///       rectangular region defined by this <see cref='System.Drawing.Rectangle'/> .
        ///    </para> 
        /// </devdoc>
        bool Contains(int x, int y);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Contains1"]/*' /> 
        /// <devdoc>
        ///    <para>
        ///       Determines if the specfied point is contained within the
        ///       rectangular region defined by this <see cref='System.Drawing.Rectangle'/> . 
        ///    </para>
        /// </devdoc> 
        bool Contains(Point pt);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Contains2"]/*' />
        /// <devdoc>
        ///    <para> 
        ///       Determines if the rectangular region represented by
        ///    <paramref name="rect"/> is entirely contained within the rectangular region represented by 
        ///       this <see cref='System.Drawing.Rectangle'/> . 
        ///    </para>
        /// </devdoc> 
        bool Contains(Rectangle rect);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.GetHashCode"]/*' /> 
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        int GetHashCode();

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Inflate"]/*' />
        /// <devdoc>
        ///    <para> 
        ///       Inflates this <see cref='System.Drawing.Rectangle'/>
        ///       by the specified amount. 
        ///    </para> 
        /// </devdoc>
        [System.Runtime.TargetedPatchingOptOutAttribute("Performance critical to inline across NGen image boundaries")]
        void Inflate(int width, int height);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Inflate1"]/*' />
        /// <devdoc> 
        ///    Inflates this <see cref='System.Drawing.Rectangle'/> by the specified amount.
        /// </devdoc>
        void Inflate(Size size);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Intersect"]/*' /> 
        /// <devdoc> Creates a Rectangle that represents the intersection between this Rectangle and rect.
        /// </devdoc> 
        void Intersect(Rectangle rect);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.IntersectsWith"]/*' /> 
        /// <devdoc>
        ///     Determines if this rectangle intersets with rect. 
        /// </devdoc>
        bool IntersectsWith(Rectangle rect);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Offset"]/*' /> 
        /// <devdoc>
        ///    <para> 
        ///       Adjusts the location of this rectangle by the specified amount.
        ///    </para>
        /// </devdoc>
        void Offset(Point pos);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.Offset1"]/*' />
        /// <devdoc> 
        ///    Adjusts the location of this rectangle by the specified amount.
        /// </devdoc>
        [System.Runtime.TargetedPatchingOptOutAttribute("Performance critical to inline across NGen image boundaries")]
        void Offset(int x, int y);

        /// <include file='doc\Rectangle.uex' path='docs/doc[@for="Rectangle.ToString"]/*' /> 
        /// <devdoc>
        ///    <para>
        ///       Converts the attributes of this <see cref='System.Drawing.Rectangle'/> to a
        ///       human readable string. 
        ///    </para>
        /// </devdoc> 
        string ToString();
    }
}