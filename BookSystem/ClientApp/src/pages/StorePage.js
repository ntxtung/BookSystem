import React from 'react'

import { connect } from 'react-redux'

import localhost5000 from '../apis/localhost5000'

import BookCard from '../components/BookCard'
import { Card, CardGroup } from 'semantic-ui-react';

class StorePage extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      books: []
    }
  }
  componentDidMount = async () => {
    let response = await localhost5000({
      method: "GET",
      url: '/books'
    })
    this.setState({books: response.data})
  }
  render() {
    const mapBook = this.state.books.map((book) => {
      return (
        <BookCard book={book}/>
      )
    })
    return (
      <CardGroup doubling itemsPerRow={5}> 
        {mapBook}
      </CardGroup>
    )
  }
}

const mapStateToProps = (state) => {
  return {
    loggedInUser: state.loggedInUser
  };
}

export default connect(mapStateToProps, {})(StorePage)