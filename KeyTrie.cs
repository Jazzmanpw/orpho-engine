using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceFix
{
    /// <summary>
    /// Prefix tree that holds no values
    /// because the keys themselves are values.
    /// Needs an alphabet provided by user.
    /// Thus can be ordered using some real language.
    /// </summary>
    class KeyTrie
    {
        class Node
        {
            //Constructors
            public Node(char name, int depth)
            {
                this.name = name;
                Depth = depth;
                childern = new Node[alphabet.Count];
            }

            //Fields
            Node[] childern;
            readonly char name;

            //Properties
            public int Depth { get; }
            public bool Valuable { get; set; }
            public Node this[char c]
            {
                get
                {
                    return
                        alphabet.ContainsKey(c) ?
                        childern[alphabet[c]] : null;
                }
                private set
                {
                    if (alphabet.ContainsKey(c))
                        childern[alphabet[c]] = value;
                }
            }
            //Operators
            public static implicit operator char(Node n) => n.name;

            //Methods
            public Node GetChildStrict(char c) =>
                this[c] ?? (this[c] = new Node(c, Depth + 1));
            public override string ToString() =>
                name == '\0' ? "root" : name.ToString();
            public bool HasChild(char c) => this[c] != null;
        }

        public KeyTrie(char[] abc)
        {
            //abcLength = abc.Length;
            alphabet = new Dictionary<char, int>(abc.Length);
            for (int i = 0; i < abc.Length; i++)
                alphabet[abc[i]] = i;
            root = new Node('\0', 0);
        }

        //Fields
        readonly Node root;
        static Dictionary<char, int> alphabet;
        string varFinalizer = " ";
        ArgumentException canNotSeparate = new ArgumentException(
                "The argument can not be separated as a set of keys.",
                "keys");
        ArithmeticException noCheckPointsFoundException =
            new ArithmeticException("It was on purpose");

        //Properties
        public string[] Keys
        {
            get
            {
                string word = string.Empty;
                List<string> keys = new List<string>();
                GetAllKeys(root, ref word, ref keys);
                return keys.ToArray();
            }
        }

        //Methods
        public void Add(string key)
        {
            Node current = root;
            foreach (char c in key)
                current = current.GetChildStrict(c);
            current.Valuable = true;
        }
        /// <summary>
        /// The most simple way to delete the valuable key.
        /// </summary>
        /// <param name="key">The key to delete</param>
        public void Delete(string key)
        {
            Node current = GetNode(key);
            if (current?.Valuable ?? false) current.Valuable = false;
        }
        public bool? Valuable(string key) => GetNode(key)?.Valuable;
        Node GetNode(string key)
        {
            Node current = root;
            foreach (char c in key)
                if (current == null) return null;
                else current = current[c];
            return current;
        }
        void GetAllKeys(Node node, ref string word, ref List<string> keys)
        {
            foreach (char letter in alphabet.Keys)
            {
                if (node[letter] == null) continue;
                word += node[letter].ToString();
                if (node[letter].Valuable) keys.Add(word);
                GetAllKeys(node[letter], ref word, ref keys);
            }
            if (word != string.Empty) word = word.Remove(word.Length - 1);
        }
        public string[][] SeparateKeys(string keys)
        {
            if (keys == string.Empty) throw new ArgumentException(
                "The concatenated keys string must be not empty.", "keys");

            //Initializing locals
            List<List<string>> keysVariants =
                new List<List<string>>()
                { new List<string>() { string.Empty } };
            Node
                current = root;
            int
                keyNum = 0,
                lastI = keys.Length - 1,
                varNum = 0;
            bool isError = false;
            Node[]
                checkPoints = new Node[keys.Length];

            //Separating keys
            for (int i = 0; i < keys.Length; i++)
            {
                //Going through the entered string
                current = current[char.ToLower(keys[i])];
                if (current == null)
                    isError = true;
                else
                {
                    keysVariants[varNum][keyNum] += keys[i];
                    if (current.Valuable)
                    {
                        if (i != lastI && current.HasChild(keys[i + 1]))
                            checkPoints[i] = current;
                        keysVariants[varNum].Add(
                            i == lastI ?
                            varFinalizer :
                            string.Empty);
                        keyNum++;
                        current = root;
                    }
                }

                //Going back to a checkpoint
                if (isError || i == lastI)
                    for (int j = i; j >= 0; j--)
                        if (checkPoints[j] != null)
                        {
                            //Go back to the checkpoint
                            current = checkPoints[j];
                            i = j;

                            //Delete the checkpoint
                            checkPoints[j] = null;

                            //Copy true keys
                            keysVariants.Add(new List<string>());
                            keyNum = -1;
                            for (int writtenChars = 0;//, repeatedKeyNum = 0;
                                writtenChars != j + 1;)
                            {
                                keyNum++;
                                keysVariants[varNum + 1].Add(
                                    keysVariants[varNum][keyNum]);
                                writtenChars +=
                                    keysVariants[varNum][keyNum].Length;
                                //Not exactly an overflow, but looks like
                                //the most appropriate exception in the situation.
                                //Added to prevent an infinite cycle that is not supposed
                                //to emerge if there is no bugs in the method.
                                if (writtenChars > j + 1) throw new OverflowException(
                                    "The number of written characters is bigger " +
                                    "then it ment to be.");
                            }
                            if (isError)
                            //Delete spoiled variant
                            {
                                keysVariants.RemoveAt(varNum);
                                isError = false;
                            }
                            else
                                //Increase the number of variants
                                varNum++;
                            break;
                        }
                if (isError) break;
            }

            //Removing variants not ending with a key
            for (int i = 0; i < keysVariants.Count; i++)
                if (keysVariants[i].Last() != varFinalizer)
                {
                    keysVariants.Remove(keysVariants[i--]);
                    varNum--;
                }
                else keysVariants[i].Remove(varFinalizer);
            if (keysVariants.Count == 0)
                throw canNotSeparate;

            //Returning
            string[][] result = new string[varNum + 1][];
            for (int i = 0; i < varNum + 1; i++)
            {
                result[i] = keysVariants[i].ToArray();
            }
            return result;
        }
    }
}
