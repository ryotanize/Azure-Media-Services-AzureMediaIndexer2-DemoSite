using System;
using System.IO;
using System.Collections.Generic;

namespace AzureMediaIndexer
{
    class VTTTranslator
    {
        private string authKey = string.Empty;

        public string from = "ja";  // default
        public string to = "en";
        private const int charactorLimit = 10000;
        private const int arrayLimit = 2000;

        public int executeTranslateLineNumber = charactorLimit / 100;
        private MicrosoftTranslator translator;

        public VTTTranslator(string key)
        {
            translator = new MicrosoftTranslator(key);
        }

        public void Translate(string SourceFilePath, string outputFilePath)
        {

            // Reads all lines into the array we would be processing/translating
            string[] lines = File.ReadAllLines(SourceFilePath);

            // Translate the line/dialog and update the translated array
            int arrayFilledCount = 0;
            List<string> origins = new List<string>();
            List<string> translateds = new List<string>();
            string[] results = new string[lines.Length];

            // Start iterating each line in the VTT file format
            for (int counter = 0; counter < lines.Length; counter++)
            {
                if (lines[counter].Length > 0)
                {
                    // Start processing text after the time indicator
                    if (lines[counter][2] == ':')
                    {
                        counter++;
                        origins.Add(lines[counter]);
                        arrayFilledCount++;

                        if (arrayFilledCount > executeTranslateLineNumber)
                        {
                            arrayFilledCount = 0;

                            translator.from = from;
                            translator.to = to;
                            translateds.AddRange(
                                translator.TranslateArray(
                                    origins.ToArray()
                                    )
                                   );
                            origins.Clear();
                        }


                    }
                }
            }

            if (origins.Count > 0)
            {
                translator.from = from;
                translator.to = to;
                translateds.AddRange(translator.TranslateArray(origins.ToArray()));
            }

            // Generate Output String Array
            int pushCount = 0;
            for (int counter = 0; counter < lines.Length; counter++)
            {
                if (lines[counter].Length > 0)
                {
                    if (lines[counter][2] == ':')
                    {
                        results[counter] = lines[counter];
                        counter++;
                        results[counter] = translateds[pushCount];
                        pushCount++;
                    }
                    else
                    {
                        results[counter] = lines[counter];
                    }

                }

            }

            // Flush the translated array into the new file
            File.WriteAllLines(outputFilePath, results);

        }

    }
}
