using SuperDavis.Interface;
using SuperDavis.Object.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Command
{
    class UseQuestionBlockCommand : ICommand
    {
        private QuestionBlock questionBlock;
        public UseQuestionBlockCommand(QuestionBlock questionBlock)
        {
            this.questionBlock = questionBlock;
        }
        public void Execute()
        {
            questionBlock.UseQuestionBlock();
        }
    }
}
