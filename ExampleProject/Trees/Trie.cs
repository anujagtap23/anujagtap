using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleProject.Trees
{
    
/*
    // Design a component which will be used to add autocomplete features to a piece of software. In other words, given a dictionary of words, and a prefix, 
    //return all words in the dictionary which begin with the given prefix.
    //Design a data structure and algorithm which will implement the above portion of the library. Implement the following functionality:
    //
    //Inserting a word into the data structure
    //Querying the data structure to determine the set of words which have a common prefix


    //ta
    // tarzan, tarry, tars, tar

    //trie   taz  tarzy

             -> s
   t -> a -> r(w) -> z -> a -> n(w)
            -> r -> y
//lower case alpha
*/
public class TrieProblem
    {
        class TrieNode
        {

            // R links to node children
            private TrieNode[] links;

            private const int R = 26;

            private bool isEnd;

            public TrieNode()
            {
                links = new TrieNode[R];
            }

            public bool containsKey(char ch)
            {
                return links[ch - 'a'] != null;
            }
            public TrieNode get(char ch)
            {
                return links[ch - 'a'];
            }
            public void put(char ch, TrieNode node)
            {
                links[ch - 'a'] = node;
            }
            public void setEnd()
            {
                isEnd = true;
            }
            public bool isEndOfWord()
            {
                return isEnd;
            }
        }

        class Trie : IComparable
        {
            char value;
            List<Trie> children;
            bool isWord;

            public int CompareTo(object obj)
            {
                
                Trie newObj = obj as Trie;
                return this.value.CompareTo(newObj.value);
            }
        }

        Trie[] TrieStructure = new Trie[26];

       
/*
        List<string> GetStringsForGivenPrefix(string prefix)
        {

            int index = prefix[0] - 'a';
            Trie root = TrieStructure[index];
            List<string> result = new List<string>();

            for (int i = 1; i < prefix.Length; i++)
            {
                if (!root.children.Contains(prefix[i])) break;

                root = root.children[prefix[i]];
            }



            return result;
        }

        void BuildTrieFronDictionary(List<string> dict)
        {
            foreach (string str in dict)
            {
                int index = str[0] - 'a';
                Trie root = TrieStructure[index];
                Trie lastCharNode;
                for (int i = 1; i < str.Length; i++)
                {
             /*       if (root.children != null && root.Children.Contains(str[i])
                    {
                        root = root.Children[str[i]];
                        lastCharNode = root;
                    }
                    else
                    {
                        lastCharNode = new Trie(str[i]), nreList<>(), false);
                root.children.Add(lastCharNode);
                root = lastCharNode;
  
            }

        }
        lastCharNode.isWord = true;            
*/
        }

}
