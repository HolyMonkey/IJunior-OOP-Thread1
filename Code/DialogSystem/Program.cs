using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            //DialogNode node2 = null;
            //DialogNode node1 = new DialogNode("Вы орк?", node2, null, Answer.Yes);
            //node2 = new DialogNode("А ваша мама была орком?", null, node1, Answer.No);

            DialogTreeBuilder builder = new DialogTreeBuilder();

            builder.MakeNode("Вы орк?").
                SetNegativeLine(builder.MakeNode("Бывает").
                                SetPositiveLine(builder.MakeNode("Замыкающая нода"))).
                SetPositiveLine(builder.MakeNode("А ваша мама была орком?").
                                SetPositiveLine(builder.GetNode("Замыкающая нода")));

            DialogTreeGui gui = new DialogTreeGui(builder.Build(0));
            gui.Start();
        }
    }

    class DialogTreeBuilder
    {
        private List<DialogTreeBuilderNode> _nodes = new List<DialogTreeBuilderNode>();
        private int _ids;

        public NodeBuilder MakeNode(string question, Answer answer = Answer.Yes)
        {
            var node = new DialogTreeBuilderNode(new DialogNode(question, null, null, answer),
                        ++_ids);
            _nodes.Add(node);

            return new NodeBuilder(node, this);
        }

        public NodeBuilder GetNode(string question)
        {
            DialogTreeBuilderNode node = null;

            foreach (var n in _nodes)
            {
                if (n.Node.Question == question)
                {
                    node = n;
                }
            }

            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return new NodeBuilder(node, this);
        }

        public void SetPositiveLine(int from, int to)
        {
            foreach (var maybeFrom in _nodes)
            {
                if (maybeFrom.Id == from)
                {
                    foreach (var maybeTo in _nodes)
                    {
                        if (maybeTo.Id == to)
                        {
                            maybeFrom.Node.PositiveNode = maybeTo.Node;
                            return;
                        }
                    }
                }
            }

            throw new InvalidOperationException();
        }

        public DialogTree Build(int rootId)
        {
            foreach (var maybeRoot in _nodes)
            {
                if (maybeRoot.Id == rootId)
                {
                    return new DialogTree(maybeRoot.Node);
                }
            }

            return null;
        }

        public class NodeBuilder
        {
            private DialogTreeBuilderNode _node;
            private DialogTreeBuilder _builder;

            public NodeBuilder(DialogTreeBuilderNode node, DialogTreeBuilder builder)
            {
                _node = node;
                _builder = builder;
            }

            public NodeBuilder SetPositiveLine(int to)
            {
                foreach (var maybeTo in _builder._nodes)
                {
                    if (maybeTo.Id == to)
                    {
                        _node.Node.PositiveNode = maybeTo.Node;
                    }
                }

                return this;
            }

            public NodeBuilder SetPositiveLine(NodeBuilder to)
            {
                _node.Node.PositiveNode = to._node.Node;

                return this;
            }

            public NodeBuilder SetNegativeLine(int to)
            {
                foreach (var maybeTo in _builder._nodes)
                {
                    if (maybeTo.Id == to)
                    {
                        _node.Node.NegativeNode = maybeTo.Node;
                    }
                }

                return this;
            }

            public NodeBuilder SetNegativeLine(NodeBuilder to)
            {
                _node.Node.NegativeNode = to._node.Node;
                return this;
            }
        }
    }

    class DialogTreeBuilderNode
    {
        public DialogNode Node;
        public int Id;

        public DialogTreeBuilderNode(DialogNode node, int id)
        {
            Node = node;
            Id = id;
        }
    }

    class DialogTreeGui
    {
        private DialogTree _tree;

        public DialogTreeGui(DialogTree tree)
        {
            _tree = tree;
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine(_tree.Current.Question);
                Console.WriteLine("Можно ответить Да/Нет");
                string answer = Console.ReadLine();
                if (answer.ConvertToAnswer().HasValue)
                {
                    _tree.PushAnswer(answer.ConvertToAnswer().Value);
                }
            }
        }
    }

    class DialogTree
    {
        public DialogNode Current { get; private set; }

        public DialogTree(DialogNode current)
        {
            Current = current;
        }

        public void PushAnswer(Answer answer)
        {
            Current = Current.CheckAnswer(answer);
        }
    }

    enum Answer
    {
        Yes,
        No
    }

    class DialogNode
    {
        public string Question;
        public DialogNode PositiveNode, NegativeNode;

        public Answer PositiveAnswer = Answer.Yes; //"Нет"

        public DialogNode(string question, DialogNode positiveNode, DialogNode negativeNode, Answer positiveAnswer)
        {
            Question = question;
            PositiveNode = positiveNode;
            NegativeNode = negativeNode;
            PositiveAnswer = positiveAnswer;
        }

        public DialogNode CheckAnswer(Answer answer)
        {
            if (answer == PositiveAnswer)
            {
                return PositiveNode;
            }
            else
            {
                return NegativeNode;
            }
        }
    }

    static class StringExtensions
    {

        public static Answer? ConvertToAnswer(this string str)
        {
            str = str.ToLower().Trim();
            if (str == "yes" || str == "да")
            {
                return Answer.Yes;
            }
            else if (str == "no" || str == "нет")
            {
                return Answer.No;
            }
            else
            {
                return null;
            }
        }
    }
}
