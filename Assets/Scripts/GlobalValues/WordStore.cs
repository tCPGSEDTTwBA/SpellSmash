using System.Collections;

static class WordStore
{
    private static ArrayList WORDS = new ArrayList()
    {
        {"TTT"},
    };

    public static ArrayList GetWords()
    {
        return WORDS;
    }
}
