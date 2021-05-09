using System.Collections;

static class WordStore
{
    private static ArrayList WORDS = new ArrayList()
    {
        {"test"}
    };

    public static ArrayList getWords()
    {
        return WORDS;
    }
}
