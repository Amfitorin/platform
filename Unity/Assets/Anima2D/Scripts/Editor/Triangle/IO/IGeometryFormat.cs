// -----------------------------------------------------------------------
// <copyright file="IGeometryFormat.cs" company="">
// Triangle.NET code by Christian Woltering, http://triangle.codeplex.com/
// </copyright>
// -----------------------------------------------------------------------

using MyRI.Anima2D.Scripts.Editor.Triangle.Geometry;

namespace MyRI.Anima2D.Scripts.Editor.Triangle.IO
{

    /// <summary>
    /// Interface for geometry input.
    /// </summary>
    public interface IGeometryFormat
    {
        /// <summary>
        /// Read a file containing geometry information.
        /// </summary>
        /// <param name="filename">The path of the file to read.</param>
        /// <returns>An instance of the <see cref="InputGeometry" /> class.</returns>
        InputGeometry Read(string filename);
    }
}
