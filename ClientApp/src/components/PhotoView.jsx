import React from 'react'
import { Link, NavLink, useOutletContext, useParams } from 'react-router-dom';
import styles from './Styles/Post.module.css'

export default function PhotoView() {
  const params = useParams();
  const context = useOutletContext();

  const Key = ({ isRight }) => {
    const nextID = context.findIndex((item) => item === params.photoid) + (isRight ? 1 : (-1));
    return (isRight ? (nextID < context.length) : (nextID > -1)) && (
      <NavLink tag={Link} to={'../photo/' + context[nextID]} className={`${styles.key} ${isRight ? styles.keyRight : styles.keyLeft}`} >
        <div className={`${styles.arrowContainer} ${!isRight && styles.left}` }>
          <i className={`${styles.arrow}`} />
        </div>
      </NavLink>);

  }
  return (
    <div className={styles.photoView}>
      <NavLink to='../' tag={Link} className={styles.photoViewBackground} />
      <div className={styles.imageContainer}>
        <Key isRight={false} />
        <img src={`https://localhost:7216/api/Content/contentID?contentid=${params.photoid}`} alt=" " />
        <Key isRight={true} />
      </div>
    </div>
  )
}
