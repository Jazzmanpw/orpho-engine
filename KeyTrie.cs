using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceFix
{
    /// <summary>
    /// Prefix tree that holds no values
    /// because the keys themselves are values.
    /// Cannot support alphabet provided by user.
    /// Thus can not be ordered using some real language.
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
            }

            //Fields
            List<Node> children = new List<Node>();
            readonly char name;

            //Properties
            public int Depth { get; }
            public bool Valuable { get; set; }
            public Node this[char c]
            {
                get
                {
                    foreach (Node node in children)
                        if (node == c)
                            return node;
                    throw new IndexOutOfRangeException($"There is no node with '{c}' name");
                }
            }

            //Operators
            public static implicit operator char(Node n)
            { return n.name; }

            //Methods
            public Node GetChildStrict(char c)
            {
                try { return this[c]; }
                catch (IndexOutOfRangeException)
                {
                    children.Add(new Node(c, Depth + 1));
                    return children.Last();
                }
            }
            public override string ToString()
            {
                return name == default(char) ? "root" : /*Depth + "_" + */name.ToString();
            }
            public bool HasChild(char c)
            {
                try
                //Try to get acsess to the child. If there is no exception,
                //then return true. Don't know how to realise it without
                //any unnecessary call.
                { this[c].ToString(); return true; }
                catch (IndexOutOfRangeException)
                { return false; }
            }
        }

        //Fields
        readonly Node root = new Node(default(char), 0);
        List<char> alphabet = new List<char>();
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
            {
                if (!alphabet.Contains(c))
                    alphabet.Add(c);
                current = current.GetChildStrict(c);
            }
            //if (current.Valuable)
            //    throw new ArgumentException("The tree alredy contains the key.");
            current.Valuable = true;
        }
        public bool? Valuable(string key)
        {
            try { return GetNode(key).Valuable; }
            catch (KeyNotFoundException) { return null; }
        }
        /// <summary>
        /// The most simple way to delete the valuable key.
        /// </summary>
        /// <param name="key">The key to delete</param>
        public void Delete(string key)
        {
            GetNode(key).Valuable = false;
        }
        Node GetNode(string key)
        {
            Node current = root;
            foreach (char c in key)
                try
                {
                    current = current[c];
                }
                catch (IndexOutOfRangeException e)
                {
                    //throw new ArgumentException(
                    throw new KeyNotFoundException(
                      $"There is a prefix only for the first {current.Depth} characters " +
                      $"(of {key.Length} total) of the key in the tree.", e);
                }
            return current;
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
                try
                {
                    current = current[char.ToLower(keys[i])];
                    keysVariants[varNum][keyNum] += keys[i];
                    if (current.Valuable)
                    {
                        if (i != lastI && current.HasChild(keys[i + 1]))
                            checkPoints[i] = current;
                        keysVariants[varNum].Add(string.Empty);
                        keyNum++;
                        current = root;
                    }
                }
                catch (IndexOutOfRangeException)
                { isError = true; }

                //Going back to a checkpoint
                if (isError || i == lastI)
                    try
                    {
                        for (int j = i; ; j--)// j >= 0; j--)
                        {
                            if (j < 0) throw noCheckPointsFoundException;
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
                                    keysVariants.RemoveAt(varNum);
                                else
                                    //Increase the number of variants
                                    varNum++;
                                break;
                            }
                        }
                        isError = false;
                    }
                    catch (ArithmeticException e)
                    {
                        if (e != noCheckPointsFoundException)
                            throw;
                        if (keysVariants.Last().Last() != string.Empty)
                        {
                            keysVariants.RemoveAt(keysVariants.Count - 1);
                            varNum--;
                            break;
                        }
                    }
            }

            //Removing variants not ending with a key
            for (int i = 0; i < keysVariants.Count; i++)
                if (keysVariants[i].Last() != string.Empty)
                {
                    keysVariants.Remove(keysVariants[i--]);
                    varNum--;
                }
                else keysVariants[i].Remove(string.Empty);
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
        void GetAllKeys(Node node, ref string word, ref List<string> keys)
        {
            foreach (char letter in alphabet)
            {
                try
                {
                    word += node[letter];
                    if (node[letter].Valuable)
                        keys.Add(word);
                    GetAllKeys(node[letter], ref word, ref keys);
                }
                catch (IndexOutOfRangeException)
                { continue; }
            }
            if (word != string.Empty) word = word.Remove(word.Length - 1);
        }
    }
}
