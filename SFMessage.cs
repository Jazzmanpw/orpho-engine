using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFix
{
    //Enumerators
    internal enum Messages
    {
        noDictionary,
        expandingNotDone,
        textNotWrecked,
        codepageParse,
        replaceDictionary,
        canNotFix,
        deleteDictionary,
        sortingNotImplemented
    }

    static class SFMessage
    {
        static internal DialogResult Show(Messages c)
        {
            switch (c)
            {
                case Messages.noDictionary:
                    return MessageBox.Show(
                        "A dictionary must be created first.",
                        "There is no dictionary");

                case Messages.expandingNotDone:
                    return MessageBox.Show(
                        "The method to expand the dictionary must be updated first " +
                        "according to the changes made in the dictionary structure.",
                        "Upcoming task");

                case Messages.textNotWrecked:
                    return MessageBox.Show(
                        "The sample text has to be wrecked first.",
                        "Wreck it first");

                case Messages.codepageParse:
                    return MessageBox.Show(
                        "The codepage number must be" +
                        " an integer number between zero and 65 535.",
                        "Can't parse the codepage");

                case Messages.replaceDictionary:
                    return MessageBox.Show(
                        "A dictionary was already created.\n" +
                        "Do you want to replace it?",
                        "Dictionary replacing", MessageBoxButtons.YesNo);

                case Messages.canNotFix:
                    return MessageBox.Show("Entered text can not be fixed with the dictionary.\n" +
                        "May be some words have another form or typo.\n" +
                        "Please, check the text and try again");

                case Messages.deleteDictionary:
                    return MessageBox.Show(
                        "This will delete all the words from " +
                        "the dictionary. Do you want to continue?",
                        "Delete?", MessageBoxButtons.YesNo);

                case Messages.sortingNotImplemented:
                    return MessageBox.Show("The ordering of the words" +
                        "by frequency of their emerging in the processed text " +
                        "is not done yet.", "Upcoming task");

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
