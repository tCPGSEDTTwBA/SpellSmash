using System.Collections;

static class WordStore
{
    private static ArrayList WORDS = new ArrayList()
    {
        {"TEST"},
    };

    public static ArrayList GetWords()
    {
        return WORDS;
    }
}
