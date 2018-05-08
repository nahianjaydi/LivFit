/* *************************************************************************
 * ModelCaseConnectionString.cs  
 * 
 * Original version: Kari Silpiö 20.3.2014 v1.0
 *                   Modified by: Nahian Jaydi 2016
 * ------------------------------------------------------------------------
 *  Application: Model Case
 *  Layer:       Data Access Layer
 *  Class:       Connection string for the database
 * -------------------------------------------------------------------------
 * NOTE: This file can be included in your solution.
 *   If you modify this file, write your name & date after "Modified by:"
 *   DO NOT REMOVE THIS COMMENT.
 ************************************************************************* */
/// <summary>
/// Connection string for the database
/// <remarks>Original version: Kari Silpiö 2014
///          Modified by: Nahian Jaydi, 24.04.2016
/// </summary>
public class LivFitConnectionString
{
    private static string text =
        @"Data Source=(localdb)\MSSQLLocalDB;
        AttachDbFilename=|DataDirectory|\LivFitDatabase.mdf;
        Integrated Security=True;Connect Timeout=30";
    public static string Text
    {
        get { return text; }
    }

}