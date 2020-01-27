using NUnit.Framework;

namespace Markdig.Tests
{
    [TestFixture]
    public class TestTables
    {
        [Test]
        [TestCase(/* markdownText: */ "| a1 | b1 |\n|----|----|\n| a2 | b2 |\n", /* expected: */ "<table>\n<thead>\n<tr>\n<th>a1</th>\n<th>b1</th>\n</tr>\n</thead>\n<tbody>\n<tr>\n<td>a2</td>\n<td>b2</td>\n</tr>\n</tbody>\n</table>\n", /*extensions*/ "gridtables|advanced")]
        public void TestTablesBasic(string markdownText, string expected, string extensions)
        {
            var pipeline = new MarkdownPipelineBuilder().UsePipeTables().Build();
            var result = Markdown.ToHtml(markdownText, pipeline);

            Assert.AreEqual(expected, result);
            //TestParser.TestSpec(markdownText, expected, extensions, plainText: true);
        }

        [Test]
        [TestCase(/* markdownText: */ "|# a1 | # b1 |\n|----|----|\n| # a2 | # b2 |\n", /* expected: */ "<table>\n<thead>\n<tr>\n<th>a1</th>\n<th>b1</th>\n</tr>\n</thead>\n<tbody>\n<tr>\n<td>a2</td>\n<td>b2</td>\n</tr>\n</tbody>\n</table>\n", /*extensions*/ "gridtables|advanced")]
        public void TestTablesRowHeader(string markdownText, string expected, string extensions)
        {
            var pipeline = new MarkdownPipelineBuilder().UsePipeTables().Build();
            var result = Markdown.ToHtml(markdownText, pipeline);

            Assert.AreEqual(expected, result);
            //TestParser.TestSpec(markdownText, expected, extensions, plainText: true);
        }
    }
}
