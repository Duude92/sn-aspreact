import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { BASE_API_URL } from "../App";
import Posts from "./Posts";
import ProfileImage from "./ProfileImage";
import styles from "./Styles/Profile.module.css";

export default function Profile() {
  let parameters = useParams();
  const [profiledata, setProfileData] = useState({});
  const [userPosts, setUserPosts] = useState([]);
  useEffect((_) => {
    fetchProfile();
  }, []);

  let fetchProfile = async () => {
    const response = await fetch(
      BASE_API_URL + "api/profile/" + parameters.name,
      {
        method: "GET",
        headers: {
          Accept: "application/json, text/javascript",
          "Content-Type": "application/json",
        },
        mode: "cors",
      }
    );
    let profileData = await response.json();
    await setProfileData(profileData);
  };
  return (
    <div>
      <div className={styles.profile}>
        <ProfileImage authorPicture={profiledata.profileImage} />
        <div className={styles.username}>
          <h5>{profiledata.userName}</h5>
          {profiledata.fullName}
        </div>
      </div>
      {console.log(profiledata.posts)}
      <Posts data={profiledata.posts} />
    </div>
  );
}
