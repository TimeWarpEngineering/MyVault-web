namespace Herc.Pwa.Shared
{
  public class RegularExpressions
  {

    /// <summary>
    /// Number: floating point(anchored)
    ///---------------------------------
    ///
    ///^[0-9]* (?:\.[0-9]+)?$
    ///
    ///Options: Case sensitive; Exact spacing; Dot doesn’t matchline breaks; ^$ don’t matchat linebreaks; Default linebreaks
    ///
    ///        Assert position at the beginning of the string «^»
    ///Match a single character in the range between “0” and “9” «[0-9]*»
    ///   Between zero and unlimited times, as many times as possible, giving back as needed(greedy) «*»
    ///Match the regular expression below «(?:\.[0-9]+)?»
    ///   Between zero and one times, as many times as possible, giving back as needed(greedy) «?»
    ///   Match the character “.” literally «\.»
    ///   Match a single character in the range between “0” and “9” «[0-9]+»
    ///      Between one and unlimited times, as many times as possible, giving back as needed(greedy) «+»
    ///Assert position at the end of the string, or before the line break at the end of the string, if any(carriage return and line feed, next line, line separator, paragraph separator) «$»
    ///Your regular expression may find zero-length matches
    ///   Java 8 allows a zero-length match at the position where the previous match ends.
    ///   Java 8 advances one character through the string before attempting the next match if the previous match was zero-length.
    public static string FloatingPointNumberNoSign(char aDecimalSeperator) => @"^[0-9]*(?:\" + $"{aDecimalSeperator}[0-9]+)?$";


    // Password Validation

    //^(?!.* )(?=.*\d)(?=.*[A-Z])(?=.*\W).{6,}$[A-Z]{3}$

    //Assert position at the beginning of the string «^»
    //Assert that it is impossible to match the regex below starting at this position (negative lookahead) «(?!.* )»
    //   Match any single character that is not a line break character «.*»
    //      Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
    //   Match the character “ ” literally « »
    //Assert that the regex below can be matched, starting at this position (positive lookahead) «(?=.*\d)»
    //   Match any single character that is not a line break character «.*»
    //      Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
    //   Match a single digit 0..9 «\d»
    //Assert that the regex below can be matched, starting at this position (positive lookahead) «(?=.*[A-Z])»
    //   Match any single character that is not a line break character «.*»
    //      Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
    //   Match a single character in the range between “A” and “Z” «[A-Z]»
    //Assert that the regex below can be matched, starting at this position (positive lookahead) «(?=.*\W)»
    //   Match any single character that is not a line break character «.*»
    //      Between zero and unlimited times, as many times as possible, giving back as needed (greedy) «*»
    //   Match a single character that is a “non-word character” «\W»
    //Match any single character that is not a line break character «.{ 6,}»
    //   Between 6 and unlimited times, as many times as possible, giving back as needed (greedy) «{ 6,}»
    //Assert position at the end of the string (or before the line break at the end of the string, if any) «$»
    //Match a single character in the range between “A” and “Z” «[A-Z]{ 3}»
    //   Exactly 3 times «{ 3}»
    //Assert position at the end of the string (or before the line break at the end of the string, if any) «$»


    public static string PasswordValidation => @"^(?!.* )(?=.*\d)(?=.*[A-Z])(?=.*\W).{6,}$";

    // Pin Validation, Needs RegEx Buddy Description

    public static string PinValidation => @"[0-9]{4}";
  }
}
