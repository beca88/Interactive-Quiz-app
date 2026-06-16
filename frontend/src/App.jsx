import { useState, useEffect } from 'react';
import './App.css';

const API_URL = 'http://localhost:5105/api/questions';

function App() {
  const [questions, setQuestions] = useState([]);
  const [currentIndex, setCurrentIndex] = useState(0);
  const [selectedAnswer, setSelectedAnswer] = useState(null);
  const [isAnswered, setIsAnswered] = useState(false);
  const [score, setScore] = useState(0);
  const [showResult, setShowResult] = useState(false);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch(API_URL)
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch questions');
        }
        return response.json();
      })
      .then(data => {
        setQuestions(data);
        setLoading(false);
      })
      .catch(err => {
        setError(err.message);
        setLoading(false);
      });
  }, []);

  // Handle answer selection
  const handleAnswerSelect = (answer) => {
    if (isAnswered) return; // Prevent changing answer after selection
    setSelectedAnswer(answer);
    setIsAnswered(true);

    
    if (answer === questions[currentIndex].correctAnswer) {
      setScore((prevScore) => prevScore + 1);
    }
  };

  // Move to next question or show result
  const handleNext = () => {
    setSelectedAnswer(null);
    setIsAnswered(false);
    
    // Check if there are more questions
    if (currentIndex < questions.length - 1) {
      setCurrentIndex((prevIndex) => prevIndex + 1);
    } else {
      // No more questions, show result
      setShowResult(true);
    }
  };

  // Restart quiz
  const handleRestart = () => {
    setCurrentIndex(0);
    setSelectedAnswer(null);
    setIsAnswered(false);
    setScore(0);
    setShowResult(false);
  };

  // Loading and error states
  if (loading) return <h2 className="quiz-loading">Loading Quiz Questions...</h2>;
  if (error) {
    return (
      <div className="quiz-error">
        <h2>Error: Something went wrong</h2>
        <p>{error}</p>
        <button onClick={() => window.location.reload()}>Retry</button>
      </div>
    );
  }

  // Score and result display
  if (showResult) {
    return (
      <div className="result-container" style={{ textAlign: 'center', background: '#fff', padding: '30px', borderRadius: '12px' }}>
        <h2>Excellent! Your Total Score is : {score} / {questions.length}</h2>
        <button className="restart-button" onClick={handleRestart}>
          Restart Quiz
        </button>
      </div>
    );
  }

  const currentQuestion = questions[currentIndex];

  // Main quiz interface
  return (
    <div className="quiz-container">
      <div className="quiz-header">
        <h1>Interactive Quiz</h1>
        <p>Question {currentIndex + 1} of {questions.length}</p>
        <span className="score">Current Score: {score}</span>
      </div>

      <h3 className="quiz-question">{currentQuestion.questionText} <span style={{ color: '#666', fontSize: '0.9rem' }}>Click on an option to answer.</span></h3>
      
      <div className="options-list">
        {currentQuestion.options.map((option, index) => {
          // Dynamic class assignment based on correctness state
          let classNames = "option-button";
          if (isAnswered) {
            if (option === currentQuestion.correctAnswer) {
              classNames += " correct";
            } else if (option === selectedAnswer) {
              classNames += " incorrect";
            }
          }

          return (
            <button
              key={index}
              onClick={() => handleAnswerSelect(option)} 
              disabled={isAnswered}
              className={classNames}
            >
              {option}
            </button>
          );
        })}
      </div>
      
      {/* Feedback and next button after answering */}
      {isAnswered && (
        <div className="feedback-container">
          <div className={`feedback-text ${selectedAnswer === currentQuestion.correctAnswer ? 'correct' : 'incorrect'}`}>
            {selectedAnswer === currentQuestion.correctAnswer ? '✨ Correct!' : '❌ Incorrect!'}
          </div>

          <button className="next-button" onClick={handleNext}>
            {currentIndex + 1 === questions.length ? 'Finish Quiz' : 'Next Question →'}
          </button>
        </div>
      )}
    </div>
  );
}

export default App;