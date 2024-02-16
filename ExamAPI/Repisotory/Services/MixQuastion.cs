using ExamAPI.Models.DTOs.Quastion;
using System.Security.Cryptography;

namespace ExamAPI.Repisotory.Services;

public class MixQuastion
{
    public List<QuastionDto> MixQuastions(List<QuastionDto> quastions)
    {
        quastions.Shuffle();
        foreach (var quastion in quastions)
        {
            quastion.Answers.Shuffle();
        }
        return quastions;
    }
}

static class ShuffleList
{
    public static void Shuffle<T>(this IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}