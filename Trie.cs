﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SpaceFix
{
    /// <summary>
    /// Prefix tree that holds values of type.
    /// Needs an alphabet provided by user.
    /// Thus can be ordered using some real language.
    /// </summary>
    /// <typeparam name="T">
    /// The type of values stored in the trie.
    /// </typeparam>
    class Trie<T>
    {
        class Node
        {
            //Constructors
            public Node(char name, int depth, T value)
            {
                this.name = name;
                Depth = depth;
                Value = value;
                childern = new Node[alphabet.Count];
            }
            public Node(char name, int depth) :
                this(name, depth, EmptyValue)
            { }

            //Fields
            Node[] childern;
            readonly char name;

            //Properties
            public int Depth { get; }
            public T Value { get; set; }
            public bool Valuable => !Value.Equals(EmptyValue);
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

        //Constructors
        public Trie(char[] abc, string name = null, T emptyValue = default(T))
        {
            //abcLength = abc.Length;
            alphabet = new Dictionary<char, int>(abc.Length);
            EmptyValue = emptyValue;
            Name = name;
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
        public T[] Values
        {
            get
            {
                List<T> values = new List<T>();
                GetAllValues(root, ref values);
                return values.ToArray();
            }
        }
        /// <summary>
        /// Name of property stored in values.
        /// </summary>
        public string Name { get; }
        public static T EmptyValue { get; private set; }

        //Methods
        /// <summary>
        /// Adds the key, if absent, and the value to the key.
        /// If the key already has a value, rewrite it.
        /// </summary>
        /// <param name="key">The key to hold the value.</param>
        /// <param name="value">The value to add.</param>
        public void Add(string key, T value)
        {
            Node current = root;
            foreach (char c in key)
                current = current.GetChildStrict(c);
            current.Value = value;
        }
        /// <summary>
        /// If the key has no value or is absent, adds the value
        /// (or the key and the value) and returns true.
        /// If key already holds a value returns false.
        /// </summary>
        /// <param name="key">The key to check and to hold the value.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>True, if operation was successful, otherwise false.</returns>
        public bool TryAdd(string key, T value)
        {
            if (Valuable(key) ?? false) return false;
            Add(key, value);
            return true;
        }
        /// <summary>
        /// The most simple way to delete the valuable key.
        /// </summary>
        /// <param name="key">The key to delete</param>
        public void Delete(string key)
        {
            Node current = GetNode(key);
            if (current?.Valuable ?? false) current.Value = EmptyValue;
        }
        public bool? Valuable(string key) => GetNode(key)?.Valuable;
        public T GetValue(string key)
        {
            try
            { return GetNode(key).Value; }
            catch (NullReferenceException e)
            {
                throw new KeyNotFoundException(
                  "There is no such a key in the dictionary", e);
            }
        }
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
        void GetAllValues(Node node, ref List<T> values)
        {
            foreach (char letter in alphabet.Keys)
            {
                if (node[letter] == null) continue;
                if (node[letter].Valuable)
                    values.Add(node[letter].Value);
                GetAllValues(node[letter], ref values);
            }
        }
        public string[][] SeparateKeys(string keys)
        {
            return SeparateKeys<object>(keys);
        }
        public string[][] SeparateKeys<TComp>(string keys, PreprocessComparer<List<string>, TComp> pc = null)
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
                        if (i == lastI)
                            keysVariants[varNum].Add(varFinalizer);
                        else
                            foreach (List<string> trueVariant in keysVariants)
                                if (trueVariant != keysVariants[varNum] &&
                                    SteppedIntoPattern(trueVariant, keysVariants[varNum]))
                                {
                                    int subvarLength = CharsInVariant(keysVariants[varNum]);
                                    foreach (string key in trueVariant)
                                        if ((subvarLength -= key.Length) < 0)
                                            keysVariants[varNum].Add(key);
                                    keysVariants[varNum].Add(varFinalizer);
                                    i = lastI;
                                    break;
                                }
                                else
                                if (
                                    checkPoints[i] == null &&
                                    root.HasChild(char.ToLower(keys[i + 1])))
                                    checkPoints[i] = current;
                    }
                }

                //Going back to a checkpoint
                if (isError || i == lastI)
                    for (int j = i - 1; j >= 0; j--)
                        if (checkPoints[j] != null)
                        {
                            //Copy true keys
                            keysVariants.Add(new List<string>());
                            keyNum = -1;
                            for (int writtenChars = 0;
                                writtenChars != j + 1;)
                            {
                                if (writtenChars +
                                    keysVariants[varNum][++keyNum].Length >
                                    j + 1)
                                {
                                    keysVariants[varNum + 1].Add(string.Empty);
                                    for (int k = 0; writtenChars != j + 1; k++, writtenChars++)
                                        keysVariants[varNum + 1][keyNum] +=
                                            keysVariants[varNum][keyNum][k];
                                }
                                else
                                {
                                    keysVariants[varNum + 1].Add(
                                      keysVariants[varNum][keyNum]);
                                    writtenChars +=
                                        keysVariants[varNum][keyNum].Length;
                                }
                                //Not exactly an overflow, but looks like
                                //the most appropriate exception in the situation.
                                //Added to prevent an infinite cycle that is not supposed
                                //to emerge if there is no bugs in the method.
                                if (writtenChars > j + 1) throw new OverflowException(
                                    "The number of written characters is bigger " +
                                    "then it ment to be.");
                            }

                            if (isError ||
                                i == lastI &&
                                keysVariants[varNum].Last() != varFinalizer)
                            //Delete spoiled variant
                            {
                                keysVariants.RemoveAt(varNum);
                                isError = false;
                            }
                            else if (i == lastI)
                            {
                                keysVariants[varNum].Remove(varFinalizer);
                                int compResult =
                                    (varNum == 0) ? 0 :
                                        pc?.Compare(
                                            keysVariants[varNum],
                                            keysVariants[varNum - 1]) ?? 0;
                                switch (compResult)
                                {
                                    case 1:
                                        //Relpace old variants with a better one
                                        keysVariants =
                                            new List<List<string>>()
                                            {
                                                keysVariants[varNum],
                                                keysVariants[varNum + 1]
                                            };
                                        varNum = 1;
                                        break;
                                    case 0:
                                        //Increase the number of variants
                                        varNum++;
                                        break;
                                    case -1:
                                        //Remove a variant that is not good enough.
                                        keysVariants.RemoveAt(varNum);
                                        break;
                                }

                            }

                            //Go back to the checkpoint
                            current = root;
                            keysVariants[varNum].Add(string.Empty);
                            keyNum++;
                            i = j;

                            //Delete the checkpoint
                            checkPoints[j] = null;

                            break;
                        }
                if (isError || i == lastI) break;
            }
            if (keysVariants[varNum].Last() != varFinalizer)
                keysVariants.Remove(keysVariants[varNum--]);
            else keysVariants[varNum].Remove(varFinalizer);

            if (pc != null)
            {
                //Sorting
                pc.IfUseAlternative = true;
                keysVariants.Sort(pc);
                keysVariants.Reverse();
                pc.IfUseAlternative = false;

                //Repeated removal of the worst variants
                for (int i = 1; i < varNum + 1; i++)
                    if (pc.Compare(keysVariants[i], keysVariants[0]) < 0)
                    {
                        keysVariants.RemoveAt(i--);
                        varNum--;
                    }
            }

            //Returning
            string[][] result = new string[varNum + 1][];
            for (int i = 0; i < varNum + 1; i++)
                result[i] = keysVariants[i].ToArray();
            return result;
        }
        static bool SteppedIntoPattern(List<string> trueVariant, List<string> subvariant)
        {
            int subvarLength = CharsInVariant(subvariant);
            for (int i = 0; subvarLength > 0; i++)
            {
                subvarLength -= trueVariant[i].Length;
                if (subvarLength == 0 &&
                    trueVariant[i] == subvariant.Last())
                    return true;
            }
            return false;
        }
        static int CharsInVariant(List<string> variant)
        {
            int result = 0;
            foreach (string key in variant)
                result += key.Length;
            return result;
        }
    }
}
